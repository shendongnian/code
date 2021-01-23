    class MyClass
    {
        private IDictionary<string, string> propertyValueByName = new Dictionary<string, string>(); 
        public string this[string propertyName]
        {
            get { return propertyValueByName[propertyName]; }
            set { propertyValueByName[propertyName] = ModifyStringMethod(value); }
        }
        public string FirstName
        {
            get { return this["FirstName"]; }
            set { this["FirstName"] = value; }
        }
        public string LastName
        {
            get { return this["LastName"]; }
            set { this["FirstName"] = value; }
        }
    }
