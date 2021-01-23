    class VaraibleHolder
    {
        List<Variable> Variables;
        VariableHolder()
        {
            Variables = new List<Variables>(); 
        } 
    
        public void Add(Variable Vbl)
        {
            Variable vbl = Variables.SingleOrDefault(v=>v.Name == Vbl.Name);
            if(vbl == null)
            {
                Variables.Add(vbl);  
            } 
        }
     
        public void Remove(string VblName)
        {
            //this is a lamda expression.
            Variable vbl = Variables.SingleOrDefault(v=>v.Name == VblName);
            if(vbl != null)
            {
                Variables.Remove(vbl);  
            }    
        }
 
        public Variable GetVariable(string VblName)
        {
             Variable vbl = Variables.SingleOrDefault(v=>v.Name == VblName);
             return vbl;  
        } 
    }
