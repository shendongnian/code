    using FSharp.Compiler.CodeDom;
    using System.CodeDom;
    var codeString = "let add x y = x + y";
    var provider = new FSharp.Compiler.CodeDom.FSharpCodeProvider();
    Environment.CurrentDirectory.Dump("exe is going here"); // diagnostic helper
    var targetFile = "FSFoo.exe";
    provider .CompileAssemblyFromSource( new System.CodeDom.Compiler.CompilerParameters(){ OutputAssembly= targetFile, GenerateExecutable=true }, new []{codeString}).Dump(); // .Dump is just for diagnostics, remove if you aren't running this in linqpad
    if(!System.IO.File.Exists(targetFile)){
    	throw new FileNotFoundException("Could not find compiled exe",targetFile);
    }
    
    System.IO.Directory.GetFiles(Environment.CurrentDirectory,"FSFoo.exe").Dump();// .Dump is just for diagnostics, remove if you aren't running this in linqpad
