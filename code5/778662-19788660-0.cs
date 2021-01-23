    using System;
    using System.IO;
    using Microsoft.ClearScript;
    using Microsoft.ClearScript.V8;
    namespace Test
    {
        public class TypeScriptCompiler
        {
            private readonly dynamic _compiler;
            private readonly dynamic _snapshot;
            private readonly dynamic _ioHost;
            public TypeScriptCompiler(ScriptEngine engine)
            {
                engine.Evaluate(File.ReadAllText("typescript.js"));
                _compiler = engine.Evaluate("new TypeScript.TypeScriptCompiler");
                _snapshot = engine.Script.TypeScript.ScriptSnapshot;
                _ioHost = engine.Evaluate(@"({
                    writeFile: function (path, contents) { this.output = contents; }
                })");
            }
            public string Compile(string code)
            {
                _compiler.addSourceUnit("foo.ts", _snapshot.fromString(code));
                _compiler.pullTypeCheck();
                _compiler.emitUnit("foo.ts", _ioHost);
                return _ioHost.output;
            }
        }
        public static class TestApplication
        {
            public static void Main()
            {
                using (var engine = new V8ScriptEngine())
                {
                    var compiler = new TypeScriptCompiler(engine);
                    Console.WriteLine(compiler.Compile("class Foo<T> {}"));
                }
            }
        }
    }
