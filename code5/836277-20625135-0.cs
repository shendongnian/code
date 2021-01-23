	public static class PluginResolver
	{
		private static bool hooked = false;
		public static string PluginBasePath { get; private set; }
		
		public static void Init(string BasePath)
		{
			PluginBasePath = BasePath;
			if (!hooked)
			{
				AppDomain.CurrentDomain.AssemblyResolve += ResolvePluginAssembly;
				hooked = true;
			}
		}
		static Assembly ResolvePluginAssembly(object sender, ResolveEventArgs args)
		{
			var asmName = new AssemblyName(args.Name).Name + ".dll";
			var assemblyFiles = Directory.EnumerateFiles(PluginBasePath, "*.dll", SearchOption.AllDirectories);
			var asmFile = assemblyFiles.FirstOrDefault(fn => string.Compare(Path.GetFileName(fn), asmName, true) == 0);
			if (string.IsNullOrEmpty(asmFile))
				return null;
			return Assembly.LoadFile(asmFile);
		}
	}
