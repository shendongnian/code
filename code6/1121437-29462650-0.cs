    public class UploadAttribute : Attribute
    {
        private Type _resourceType;
        private Lazy<string> _select;
        private Lazy<string> _change;
        private Lazy<string> _remove;
        UploadAttribute()
        {
            _select = new Lazy<string>(() => GetResourceText("Select", "Select..."));
            _change = new Lazy<string>(() => GetResourceText("Change", "Change..."));
            _remove = new Lazy<string>(() => GetResourceText("Remove", "Remove..."));
        }
        public Type ResourceType
        {
            get { return _resourceType; }
            set { _resourceType = value; }
        }
        public string Select
        {
            get { return _select.Value; }
            set { _select = new Lazy<string>(() => value); }
        }
        public string Change
        {
            get { return _change.Value; }
            set { _change = new Lazy<string>(() => value); }
        }
        public string Remove
        {
            get { return _remove.Value; }
            set { _remove = new Lazy<string>(() => value); }
        }
        private string GetResourceText(string key, string @default)
        {
            var result = @default;
            if (_resourceType != null && !string.IsNullOrEmpty(key))
            {
                ResourceManager rm = new ResourceManager(_resourceType);
                try
                {
                    result = rm.GetString(key);
                }
                catch
                {
                    // if string wasn't found in resource file than use what user specify; don't by big brother.
                }
            }
            return result;
        }
    }
