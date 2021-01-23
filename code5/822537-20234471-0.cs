    using Roslyn.Scripting.CSharp;
 
    namespace RoslynScriptingDemo {
        class Program {
            static void Main(string[] args)        {
                var engine = new ScriptEngine();
                engine.Execute(@"System.Console.WriteLine((450*5)+((3.14*7)/50)*100);");
            }
        }
    }
