    public static class ResxTester
	{
		public static void TestResxForInconsistencies(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException(nameof(type));
			}
			var cultureResourceDictionaries = ResxTester.GetResxDictionaries(type);
			var emptyEntries = ResxTester.GetEmpty(cultureResourceDictionaries);
			var neutralLanguage = ResxTester.ExtractNeutralLanguage(cultureResourceDictionaries, type);
			var missingEntries = ResxTester.GetMissing(cultureResourceDictionaries, neutralLanguage);
			var dispensableEntries = ResxTester.GetDispensable(cultureResourceDictionaries, neutralLanguage);
			if (emptyEntries.Count > 0
				|| missingEntries.Count > 0
				|| dispensableEntries.Count > 0)
			{
				var message = new StringBuilder();
				message.AppendFormat("Found resx errors in \"{0}\":", type);
				message.AppendLine();
				message.AppendLine();
				ResxTester.Append(message, emptyEntries, " Empty Entries ", "Entries which do not have a value.");
				ResxTester.Append(message, missingEntries, " Missing Entries ", "Entries which are specified in the neutral language but are missing in the specified language.");
				ResxTester.Append(message, dispensableEntries, " Dispensable Entries ", "Entries which are not specified in the neutral language but are present in the specified language and should be removed.");
				throw new AssertException(message.ToString());
			}
		}
		private static void Append(StringBuilder message, Dictionary<string, List<string>> entries, string headline, string description)
		{
			if (entries.Count > 0)
			{
				message.AppendLine(headline);
				message.AppendLine(new string('=', headline.Length));
				message.Append("(");
				message.Append(description);
				message.AppendLine(")");
				foreach (var pair in entries)
				{
					var languageName = pair.Key;
					if (string.IsNullOrEmpty(languageName))
					{
						languageName = "<neutral language>";
					}
					var line = string.Format("  Language: {0}  ", languageName);
					message.AppendLine(line);
					message.AppendLine(new string('-', line.Length));
					foreach (var key in pair.Value)
					{
						message.Append("\t");
						message.AppendLine(key);
					}
				}
				message.AppendLine();
			}
		}
		private static Dictionary<string, object> ExtractNeutralLanguage(Dictionary<string, Dictionary<string, object>> resxs, Type type)
		{
			Dictionary<string, object> neutralLanguage;
			if (!resxs.TryGetValue(string.Empty, out neutralLanguage))
			{
				throw new AssertException(string.Format("The neutral language is not specified in \"{0}\".", type));
			}
			resxs.Remove(string.Empty);
			return neutralLanguage;
		}
		private static CultureInfo[] GetAvailableResxCultureInfos(Assembly assembly)
		{
			var assemblyResxCultures = new HashSet<CultureInfo>();
			// must have invariant culture
			assemblyResxCultures.Add(CultureInfo.InvariantCulture);
			string[] names = assembly.GetManifestResourceNames();
			if (names != null && names.Length > 0)
			{
				var allCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
				const string resourcesEnding = ".resources";
				for (int i = 0; i < names.Length; i++)
				{
					var name = names[i];
					if (string.IsNullOrWhiteSpace(name)
						|| name.Length <= resourcesEnding.Length
						|| !name.EndsWith(resourcesEnding, StringComparison.InvariantCultureIgnoreCase))
					{
						continue;
					}
					name = name.Remove(name.Length - resourcesEnding.Length, resourcesEnding.Length);
					if (string.IsNullOrWhiteSpace(name))
					{
						continue;
					}
					var resourceManager = new ResourceManager(name, assembly);
					for (int j = 0; j < allCultures.Length; j++)
					{
						var culture = allCultures[j];
						try
						{
							// we got InvariantCulture
							// don't use "==", it does not work
							if (culture.Equals(CultureInfo.InvariantCulture))
							{
								continue;
							}
							using (var resourceSet = resourceManager.GetResourceSet(culture, true, false))
							{
								if (resourceSet != null)
								{
									assemblyResxCultures.Add(culture);
								}
							}
						}
						catch (CultureNotFoundException)
						{
							// NOP
						}
					}
				}
			}
			return assemblyResxCultures.ToArray();
		}
		private static Dictionary<string, Dictionary<string, object>> GetResxDictionaries(Type type)
		{
			var availableResxsCultureInfos = ResxTester.GetAvailableResxCultureInfos(type.Assembly);
			var resourceManager = new ResourceManager(type.FullName, type.Assembly);
			var resxDictionaries = new Dictionary<string, Dictionary<string, object>>();
			for (int i = 0; i < availableResxsCultureInfos.Length; i++)
			{
				var cultureInfo = availableResxsCultureInfos[i];
				var resourceSet = resourceManager.GetResourceSet(cultureInfo, true, false);
				if (resourceSet == null)
				{
					throw new AssertException(string.Format("The language \"{0}\" is not specified in \"{1}\".", cultureInfo.Name, type));
				}
				var dict = new Dictionary<string, object>();
				foreach (DictionaryEntry item in resourceSet)
				{
					var key = item.Key.ToString();
					var value = item.Value;
					dict.Add(key, value);
				}
				resxDictionaries.Add(cultureInfo.Name, dict);
			}
			return resxDictionaries;
		}
		private static Dictionary<string, List<string>> GetDispensable(Dictionary<string, Dictionary<string, object>> resxDictionaries, Dictionary<string, object> neutralLanguage)
		{
			var dispensable = new Dictionary<string, List<string>>();
			foreach (var pair in resxDictionaries)
			{
				var resxs = pair.Value;
				var list = new List<string>();
				foreach (var key in resxs.Keys)
				{
					if (!neutralLanguage.ContainsKey(key))
					{
						list.Add(key);
					}
				}
				if (list.Count > 0)
				{
					dispensable.Add(pair.Key, list);
				}
			}
			return dispensable;
		}
		private static Dictionary<string, List<string>> GetEmpty(Dictionary<string, Dictionary<string, object>> resxDictionaries)
		{
			var empty = new Dictionary<string, List<string>>();
			foreach (var pair in resxDictionaries)
			{
				var resxs = pair.Value;
				var list = new List<string>();
				foreach (var entrie in resxs)
				{
					if (entrie.Value == null)
					{
						list.Add(entrie.Key);
						continue;
					}
					var stringValue = entrie.Value as string;
					if (string.IsNullOrWhiteSpace(stringValue))
					{
						list.Add(entrie.Key);
					}
				}
				if (list.Count > 0)
				{
					empty.Add(pair.Key, list);
				}
			}
			return empty;
		}
		private static Dictionary<string, List<string>> GetMissing(Dictionary<string, Dictionary<string, object>> resxDictionaries, Dictionary<string, object> neutralLanguage)
		{
			var missing = new Dictionary<string, List<string>>();
			foreach (var pair in resxDictionaries)
			{
				var resxs = pair.Value;
				var list = new List<string>();
				foreach (var key in neutralLanguage.Keys)
				{
					if (!resxs.ContainsKey(key))
					{
						list.Add(key);
					}
				}
				if (list.Count > 0)
				{
					missing.Add(pair.Key, list);
				}
			}
			return missing;
		}
	}
