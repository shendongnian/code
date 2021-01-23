    public class UploadAttribute : Attribute
    {
        private Type _resourceType;
        private Lazy<string> _select;
        private Lazy<string> _change;
        private Lazy<string> _remove;
        UploadAttribute()
        {
            _select = new Lazy<string>(() => GetResourceText(m => m.Select, "Select..."));
            _change = new Lazy<string>(() => GetResourceText(m => m.Change, "Change..."));
            _remove = new Lazy<string>(() => GetResourceText(m => m.Remove, "Remove..."));
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
        private string GetResourceText(Expression<Func<UploadAttribute, string>> expression, string @default)
        {
            var result = @default;
            var memberExpression = expression.Body as MemberExpression;
            if (_resourceType != null && memberExpression != null)
            {
                ResourceManager rm = new ResourceManager(_resourceType);
                try
                {
                    result = rm.GetString(memberExpression.Member.Name);
                }
                catch
                {
                    // if string wasn't found in resource file than use what user specify; don't by big brother.
                }
            }
            return result;
        }
    }
