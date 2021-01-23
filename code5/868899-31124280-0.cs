		Dictionary<string, List<string>> _fontNameToFiles; 
		/// <summary>
		/// This is a brute force way of finding the files that represent a particular
        /// font family.
		/// The first call may be quite slow.
		/// Only finds font files that are installed in the standard directory.
		/// Will not discover font files installed after the first call.
		/// </summary>
		/// <returns>enumeration of file paths (possibly none) that contain data
        /// for the specified font name</returns>
		private IEnumerable<string> GetFilesForFont(string fontName)
		{
			if (_fontNameToFiles == null)
			{
				_fontNameToFiles = new Dictionary<string, List<string>>();
				foreach (var fontFile in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Fonts)))
				{
					var fc = new PrivateFontCollection();
					try
					{
						fc.AddFontFile(fontFile);
					}
					catch (FileNotFoundException)
					{
						continue; // not sure how this can happen but I've seen it.
					}
					var name = fc.Families[0].Name;
					// If you care about bold, italic, etc, you can filter here.
					List<string> files;
					if (!_fontNameToFiles.TryGetValue(name, out files))
					{
						files = new List<string>();
						_fontNameToFiles[name] = files;
					}
					files.Add(fontFile);
				}
			}
			List<string> result;
			if (!_fontNameToFiles.TryGetValue(fontName,  out result))
				return new string[0];
			return result;
		}
