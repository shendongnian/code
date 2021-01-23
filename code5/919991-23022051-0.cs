	<#@ template debug="true" hostspecific="true" language="C#" #>
	<#@ output extension=".vsdocs.cs" #>
	<#@ assembly name="EnvDTE" #>
	<#@ assembly name="System.Core" #>
	<#@ import namespace="System.IO" #>
	<#@ import namespace="System.Linq" #>
	<#@ import namespace="System.Collections.Generic" #>
	<#@ import namespace="Microsoft.CSharp" #>
	<#@ import namespace="System.CodeDom.Compiler" #>
	<#@ import namespace="System.Reflection" #>
	<#@ import namespace="System.CodeDom.Compiler" #>
	<#@ import namespace="System.Reflection" #>
	<#
	//System.Diagnostics.Debugger.Break();
	// Setup Environment
	var dte = (EnvDTE.DTE)((IServiceProvider)Host).GetService(typeof(EnvDTE.DTE));
	var project = dte.Solution.FindProjectItem(Host.TemplateFile).ContainingProject;
	string path = this.Host.ResolvePath("");
	string binpath = Path.Combine(path, "bin");
	// Setup Loading File
	string IBarCs = Path.Combine(path, "IBar.cs");
	string IBarDll = Path.Combine(binpath, "IBar.Dll");
	string IBarName = "ConsoleApplication10.IBar";
	// Compile File to Temporary DLL
	var cProvider = CodeDomProvider.CreateProvider("CSharp");
	CompilerParameters cp = new CompilerParameters();
	cp.GenerateExecutable = false;
	cp.OutputAssembly = IBarDll;
	CompilerResults cr = cProvider.CompileAssemblyFromFile(cp, IBarCs);
	if(cr.Errors.Count > 0)
	{
		// Display compilation errors.
		WriteLine("// Errors building {0} into {1}",  IBarCs, cr.PathToAssembly);
		foreach(CompilerError ce in cr.Errors)
		{
			WriteLine("//  {0}", ce.ToString());
		}
	}
	// Load File for Reflection
	var ibar = Assembly.LoadFile(IBarDll);
	var iBarType = ibar.GetType(IBarName);
		WriteLine("// " + iBarType.ToString());
	var methods = iBarType.GetMethods().ToList();
	foreach (var method in methods)
	{
		WriteLine("// " + method);
	}
	#>
	// Empty File
