    public class MyType
    {
        private string _description = default(string); // Note the default is NULL, not "" for a string
        // However, why not determine the default yourself?
        private string _location = "";
        private string _provider;
        public MyType()
        {
            // Or use the constructor to set the defaults
            _provider = string.Empty;
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
