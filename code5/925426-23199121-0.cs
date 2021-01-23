    class Car
    {
        public override string ToString()
        {
            return "basic car details"; // Return some details available on all cars
        }
    }
    
    class Hatchback : Car
    {
         public string GetHatchbackDetails()
         {
             return "some hatchback details";  // Return some details only hatchbacks have
         }
    }
