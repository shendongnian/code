    var mainMembers = new CSharpCodeProvider()
        .CreateCompiler()
        .CompileAssemblyFromSource(
            new CompilerParameters { GenerateInMemory = true }
            , @"
            using System; 
            using System.IO;
            public class M {
                public static int Main() { 
                    Console.WriteLine(""CurDir = ""+ Environment.CurrentDirectory); 
                    var reader = new StreamReader(""in.txt"");
                    string input = reader.ReadLine();
                    var writer = new StreamWriter(""out.txt"");
                    writer.WriteLine(input);
                    return 0;
                }
            }")
         .CompiledAssembly
         .GetType("M")
         .GetMember("Main");
     // inspect
     Environment.CurrentDirectory.Dump("current");
     // keep 
     var oldcd = Environment.CurrentDirectory;
     // switch
     Environment.CurrentDirectory = "c:\\temp";
     // invoke external code
     ((MethodInfo) mainMembers[0]).Invoke(null,null);
     // restore
     Environment.CurrentDirectory = oldcd;
