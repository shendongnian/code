      public class CarModelFromDB
      {
          public string CarName{get;set;}
          //More properties
          public IEnumerable<Wheel> Wheel{get;set;}
      }  
      
      @model IEnumerable<CarModelFromDB>
      
      @foreach(var car in Model)
      {
          //some View Code
          @foreach(var wheel in Car.Wheels.Where(x=>x.IsRound=true))
          {
             <span>wheel.Color</span> 
             // some View Code
          }
      }
