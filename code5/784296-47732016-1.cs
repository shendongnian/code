		public async Task<ActionResult> Id(string id = null)
		{
			string storyFilename = id;
			// 1) Get the View - story file
			if (storyFilename == null || storyFilename.Contains('.'))
				return Redirect("/");	// Disallow ../ for example
			string path = App.O.AppRoot + App.HomeViews + @"story\" + storyFilename + ".cshtml";
			if (!System.IO.File.Exists(path))
				return Redirect("/");
			// 2) It exists - begin parsing it for StoryDataIds
			var lines = await FileHelper.ReadLinesUntilAsync(path, line => line.Contains("@section"));
			// 3) Is there a line that says "new StoryDataIds"?
			int i = 0;
			int l = lines.Count;
			for (; i < l && !lines[i].Contains("var dataIds = new StoryDataIds"); i++)
			{}
			if (i == l)	// No StoryDataIds defined, just pass an empty StoryViewModel
				return View(storyFilename, new StoryViewModel());
			
			// https://stackoverflow.com/questions/1361965/compile-simple-string
			// https://msdn.microsoft.com/en-us/library/system.codedom.codecompileunit.aspx
			// https://msdn.microsoft.com/en-us/library/system.codedom.compiler.codedomprovider(v=vs.110).aspx
			string className = "__StoryData_" + storyFilename;
			string code = String.Join(" ",
				(new[] {
					"using ConservX.Areas.Home.ViewModels.Storying;",
					"public class " + className + " { public static StoryDataIds Get() {"
				}).Concat(
					lines.Skip(i).TakeWhile(line => !line.Contains("};"))
				).Concat(
					new[] { "}; return dataIds; } }" }
				));
			var refs = AppDomain.CurrentDomain.GetAssemblies();
			var refFiles = refs.Where(a => !a.IsDynamic).Select(a => a.Location).ToArray();
			var cSharp = (new Microsoft.CSharp.CSharpCodeProvider()).CreateCompiler();
			var compileParams = new System.CodeDom.Compiler.CompilerParameters(refFiles);
			compileParams.GenerateInMemory = true;
			compileParams.GenerateExecutable = false;
			var compilerResult = cSharp.CompileAssemblyFromSource(compileParams, code);
			var asm = compilerResult.CompiledAssembly;
			var tempType = asm.GetType(className);
			var ids = (StoryDataIds)tempType.GetMethod("Get").Invoke(null, null);
			using (var db... // Fetch the relevant data here
			var vm = new StoryViewModel();
			return View(storyFilename, vm);
		}
