    // Variable.
    class Variable
    {
        private Variable(XElement xVariable)
        {
            Name = xVariable.Attribute("name").Value;
            Value = xVariable.Value;
        }
    
        public static Variable Parse(XElement xVariable)
        {
            if (xVariable.Name.LocalName != "var")
            {
                return null;
            }
            return new Variable(xVariable);
        }
    
        public string Name { get; set; }
    
        public string Value { get; set; }
    }
