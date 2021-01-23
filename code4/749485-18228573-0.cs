    class a
    {
        private string b;
    
        public string b
        {
            get 
            {
                return b; // <-- ERROR! Must be _b
            }
    
            set
            {
                _b = value;
            }
        }
    }
