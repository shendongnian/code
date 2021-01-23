	public class OptionsNames
    {
        private static Dictionary<int, string> names;
        private static readonly Lazy<OptionsNames> LazyInstance = new Lazy<OptionsNames>(() => new OptionsNames());
        protected OptionsNames()
        {
            names = new Dictionary<int, string>();
            names = LoadOptionsFromXML();
        }
        public static OptionsNames Instance
        {
            get { return LazyInstance.Value; }
        }
		public static string GetNameById(int id)
		{
			if (names.ContainsKey(id))
				 return names[id];
			return string.Empty;
		}        
    }
