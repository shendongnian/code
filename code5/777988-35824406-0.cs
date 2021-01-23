		public static DirectoryInfo GetSolutionDirectory(
			string scanningOffsetDirectoryPath = null)
		{
			var directory = new DirectoryInfo(
				scanningOffsetDirectoryPath ?? Directory.GetCurrentDirectory());
			while (directory != null && !directory.GetFiles("*.sln").Any())
			{
				directory = directory.Parent;
			}
			return directory;
		}
