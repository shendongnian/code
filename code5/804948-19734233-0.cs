    class  Car: Vehicle
     {
        public string Brand {get;set;}
        public Car()
         {
           Brand="BMW";
         }
     }
    foreach(var vehicle in veichleList)
    {
      foreach(var prop in vehicle.GetType().GetProperties())
        {
          var name = prop.Name // gives you the name of the property in that class (in the above example it will be equal with "Brand")
          var val = prop.GetValue(vehicle , null) // gives you the value of that property (in the above example it will be equal with "BMW")
        }
    }
