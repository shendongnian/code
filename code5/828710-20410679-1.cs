       class Vehicle
        {
            abstract public int GetMeasurement();
        }
        
        class Car : Vehicle
        {
           //cars are measured in numberOfSeats
           override public int GetMeasurement()
           {
              return numberOfSeats;
           }
           
            private int numberOfSeats;
        }
        
       class Van: Vehicle
       {
           //vans are measured by weight
           override public int GetMeasurement()
           {
              return weight;
           }
    
          private int weight;
       }
            
      foreach (Vehicle v in vehiclelist)
      {
         //I don't need to do any type checking: 
         //polymorphism magically gets the right value for me
         lsttest.Items.Add(v.GetMeasurement());
      }
