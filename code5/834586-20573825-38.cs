    using System.IO;
    using ICSharpCode.Decompiler;
    using ICSharpCode.Decompiler.Ast;
    using Mono.Cecil;
    
    namespace Sandbox_Console
    {
        internal class Program
        {
            public static void Main()
            {
                AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly(@"C:\Code\Sandbox Form\SandboxForm\bin\Debug\SandboxForm.exe");
                var context = new DecompilerContext(assembly.MainModule);
                context.Settings.AsyncAwait = false; //If you don't do this it will show the original code with the "await" keyword and hide the state machine.
                AstBuilder decompiler = new AstBuilder(context);
                decompiler.AddAssembly(assembly);
    
                using (var output = new StreamWriter("Output.cs"))
                {
                    decompiler.GenerateCode(new PlainTextOutput(output));
                }
            }
        }
    }
