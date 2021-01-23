	using Microsoft.CSharp;
	using System;
	using System.CodeDom.Compiler;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	class Program
	{
		static void Main(string[] args)
		{
			var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v3.5" } });
			var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, "Example.exe", true);
			parameters.GenerateExecutable = true;
			CompilerResults results = csc.CompileAssemblyFromSource(parameters,
			@"using System.Linq;
				class Program {
				  public static void Main(string[] args) {}
				  public static string Main1(int abc) {
					bool myresult=false;
					if(abc==10)
					  myresult=true;
					else
					  myresult=false;
					return abc.ToString() + "": "" + (myresult ? ""myresult is true"" : ""myresult is false"");
				  }
				}");
			results.Errors.Cast<CompilerError>().ToList().ForEach(error => Console.WriteLine(error.ErrorText));
			var scriptClass = results.CompiledAssembly.GetType("Program");
			var scriptMethod1 = scriptClass.GetMethod("Main1", BindingFlags.Static | BindingFlags.Public);
			Console.WriteLine(scriptMethod1.Invoke(null, new object[] { 10 }).ToString());
			Console.WriteLine(scriptMethod1.Invoke(null, new object[] { 20 }).ToString());
		}
	}
