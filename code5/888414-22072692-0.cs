    class Anything
    {
        public Anything(string name)
        {
            if(ppp.Contains(name))
                this.name = name;
            else
                throw new ArgumentException("Name invalid");
        }
        private List<string> ppp = new List<string>()
        { 
            "table", 
            "chair", 
            "spoon", 
            "bread"
        };
    
        private string name;
    }
