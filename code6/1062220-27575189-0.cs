    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    internal sealed class SymitarInquiryDataFormatAttribute : Attribute
    {
        private readonly string _name;
    
        // This is a positional argument
        public SymitarInquiryDataFormatAttribute(string positionalString) { this._name = positionalString; }
    
        public string Name { get { return _name; } }
    }
