    class Anything
    {
        
        public Anything(string name)
        {
            Name = name;   // this will call the `set` accessor
        }
        List<string> PPP = new List<string>()
        { 
            "table", 
            "chair", 
            "spoon", 
            "bread"
        };
    
        private string name;
        
        public string Name
        {
            get {return name;}
            set 
            { 
                 if (!PPP.Contains(value)) 
                     throw now InvalidArgumentException();
       
                 name = value;
            }
        }
    }
