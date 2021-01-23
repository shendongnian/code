    class MyClass
    {
        private Dictionary<string, int> tempValues = new Dictionary<string, int>() { 
            { "CAREA", 10 }, 
            { "CAREB", 20 },
            { "CAREC", 22 },
            { "CARED", 35 }
        }
    
        public Dictionary<string, int> TempValues
        {
            get
            {
                return this.tempValues 
            }
        }
    }
