using DartSassHost;
using JavaScriptEngineSwitcher.V8;

var files = args;

var options = new CompilationOptions
{
    IndentType = IndentType.Space,
    IndentWidth = 4,
    LineFeedType = LineFeedType.CrLf,
    OutputStyle = OutputStyle.Expanded,
    SourceMap = false,
    InlineSourceMap = false
};

Console.WriteLine("Creating DartSassHost...");
using var compiler = new DartSassHost.SassCompiler(new V8JsEngineFactory());

Console.WriteLine($"Compiling files: {files.Length}");
foreach (var file in files)
{
    try
    {
        Console.WriteLine(file);
        var result = compiler.CompileFile(file, $"{file}.tmp", file, options);
        Console.WriteLine(result.CompiledContent);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}