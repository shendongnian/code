    // An if-statement.
    class IfStatement : BlockBase
    {
        private IfStatement(XElement xIf)
            : base(xIf)
        {
            Condition = xIf.Attribute("condition").Value;
        }
    
        public static IfStatement Parse(XElement xIf)
        {
            if (xIf.Name.LocalName != "if")
            {
                return null;
            }
            return new IfStatement(xIf);
        }
    
        public string Condition { get; set; }
    
        // Evaluates the condition.
        public bool Evaluate() { return bool.Parse(Condition); }
    }
    
