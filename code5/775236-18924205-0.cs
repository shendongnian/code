    interface
    {
        string SomeProp {get;}
    }
    
    class T : IMyProp
    {
        public string SomeProp 
        {
            get
            {
                //Some complicated logic
            }
        }
    }
    
    class Y : IMyProp
    {
        public string SomeProp {get; set;}
    }
