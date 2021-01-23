    public class LocalizedStrings
    {
        public string this[string key]
        {
            get
            {
                return App.ResourceLoader.GetForViewIndependentUse().GetString(key);
            }
        }
    }
