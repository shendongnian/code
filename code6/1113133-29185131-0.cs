	CodeDomProvider cdp = CodeDomProvider.CreateProvider("C#");
	CompilerParameters cp = new CompilerParameters();
	cp.GenerateInMemory = true;
	cp.GenerateExecutable = false;
	cp.IncludeDebugInformation = false;
	// add assemblies if required:
	// e.g. cp.ReferencedAssemblies.Add(...)
	CompilerResults cr = cdp.CompileAssemblyFromSource(cp, new String[] { sourceCode });
