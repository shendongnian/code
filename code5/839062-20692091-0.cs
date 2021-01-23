		public static string GetAssemblyLocation(Assembly assembly)
		{
			if (assembly.IsDynamic)
			{
				return null;
			}
			string codeBase = assembly.CodeBase;
			UriBuilder uri = new UriBuilder(codeBase);
			string path = Uri.UnescapeDataString(uri.Path);
			path = Path.GetDirectoryName(path);
			path += "\\" + Path.GetFileName(assembly.Location);
			return path;
		}
