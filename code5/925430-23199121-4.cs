    class Car
    {
        public override string ToString()
        {
            return "some basic info"; // Whatever you want
        }
    }
    
    class Hatchback : Car
    {
         public string HatchbackInfo
         {
             get{return "some hatchback info";}  // Return some details only hatchbacks have
         }
    }
