    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class SomeDataFormatAttribute : Attribute
    {
        readonly string name;
        // This is a positional argument
        public SomeDataFormatAttribute(string positionalString)
        {
            this.name = positionalString;
        }
        public string Name
        {
            get { return name; }
        }
    }
