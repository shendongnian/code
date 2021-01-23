    // Addition block.
    class Addition : BlockBase
    {
        private Addition(XElement xAddition)
        {
            Arg1 = xAddition.Attribute("arg1").Value;
            Arg2 = xAddition.Attribute("arg2").Value;
            if (!IsInScope(xAddition, Arg1))
            {
                throw new ArgumentOutOfRangeException("Arg1", String.Format("{0} is out of scope.", Arg1));
            }
            if (!IsInScope(xAddition, Arg2))
            {
                throw new ArgumentOutOfRangeException("Arg2", String.Format("{0} is out of scope.", Arg2));
            }
        }
    
        public static Addition Parse(XElement xAddition)
        {
            if (xAddition.Name.LocalName != "add")
            {
                return null;
            }
            return new Addition(xAddition);
        }
    
        public string Arg1 { get; set; }
    
        public string Arg2 { get; set; }
    
        public int? Result { get; set; }
    
        // Evaluates the addition.
        public void Evaluate()
        {
            Variable arg1 = GetVariable(Arg1);
            Variable arg2 = GetVariable(Arg2);
            if (arg1 == null)
            {
                throw new ArgumentNullException("arg1");
            }
            if (arg2 == null)
            {
                throw new ArgumentNullException("arg2");
            }
            Result = int.Parse(arg1.Value) + int.Parse(arg2.Value);
        }
    }
    
