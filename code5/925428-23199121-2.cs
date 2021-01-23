    class Car
    {
        public override string ToString()
        {
            return "some basic info"; // Whatever you want
        }
        public virtual string GetDetails()
        {
            return "some car details"; // details for basic cars
        } 
    }
    
    class Hatchback : Car
    {
         public override string GetDetails()
         {
             return "some hatchback details";  // Return some details only hatchbacks have
         }
    }
