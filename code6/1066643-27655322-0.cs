		public void Save(string key, string value)
		{
			ApplicationData.Current.LocalSettings.Values[key] = value;
		}
		public string Load(string key)
		{
			return ApplicationData.Current.LocalSettings.Values[key] as string;
		}
