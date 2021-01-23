	private static string GetTextResourceFile(string resourceName)
	{
		var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
		using (var sr = new StreamReader(stream))
		{
			return sr.ReadToEnd();
		}
	}
