      public class CarViewModel
      {
          public string CarName{get;set;}
          //More properties
          public IEnumerable<string> WheelColors{get;set;}
      }  
      
      @model dynamic
      @foreach(var car in Model)
      {
          //some View Code
          @foreach(var wheelColor in WheelColor)
          {
             <span>wheelColor</span> 
             // some View Code
          }
      }
