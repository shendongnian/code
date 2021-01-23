	var msbuildTask = new PartialClassGenerationTask()
	{
		 ApplicationMarkup = new[] { new XamlItem(@"c:\path\to\your\xaml") },
		 AssemblyName = "AssemblyName",
		 BuildTaskPath = typeof(PartialClassGenerationTask).Assembly.Location,
		 Language = "cs", // use "vb" to generate Visual Basic code
		 OutputPath = @"C:\temp",
		 References = new[]
		 {
			  new XamlItem(typeof(Uri).Assembly.Location),
			  new XamlItem(typeof(XamlLanguage).Assembly.Location),
			  new XamlItem(typeof(System.Windows.Point).Assembly.Location),
			  new XamlItem(typeof(System.Windows.Application).Assembly.Location),
			  new XamlItem(typeof(ApplicationGesture).Assembly.Location)
		 },
		 RequiresCompilationPass2 = false
	};
	msbuildTask.Execute();
