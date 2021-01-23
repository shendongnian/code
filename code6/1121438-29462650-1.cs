    public class UploadAttribute : Attribute
    {
        private static readonly string kSelectDefaultCaption = "Select...";
        private static readonly string kChangeDefaultCaption = "Change...";
        private static readonly string kRemoveDefaultCaption = "Remove...";
        private Type _resourceType;
        private Lazy<string> _select = new Lazy<string>(() => kSelectDefaultCaption);
        private Lazy<string> _change = new Lazy<string>(() => kChangeDefaultCaption);
        private Lazy<string> _remove = new Lazy<string>(() => kRemoveDefaultCaption);
        public Type ResourceType
        {
            get { return _resourceType; }
            set { _resourceType = value; }
        }
        public string Select
        {
            get { return _select.Value; }
            set { _select = new Lazy<string>(() => GetResourceText(value, kSelectDefaultCaption)); }
        }
        public string Change
        {
            get { return _change.Value; }
            set { _change = new Lazy<string>(() => GetResourceText(value, kChangeDefaultCaption)); }
        }
        public string Remove
        {
            get { return _remove.Value; }
            set { _remove = new Lazy<string>(() => GetResourceText(value, kRemoveDefaultCaption)); }
        }
        private string GetResourceText(string key, string @default)
        {
            // initialize to default.
            var result = @default;
            if (_resourceType != null && !string.IsNullOrEmpty(key))
            {
                // initialize to the value of the key, 
                // that could be a user supplied string literal
                result = key;
                // attempt to retrieve it from the resources.
                ResourceManager rm = new ResourceManager(_resourceType);
                try
                {
                    result = rm.GetString(key);
                }
                catch
                {
                    // could not retrieve key, using the key value as the result.
                }
            }
            return result;
        }
    }
