     public class MyService
     {
         public MyService(string letter)
         {
             if (letter == "A")
             {
                 this.Name = "Service A";
                 // Set other property values for service A
             }
             else if (letter == "B")
             {
                 this.Name = "Service B";
                 // Set other property values for service B
             }
             else
             {
                 throw new NotImplementedException();
             }
         }
         public string Name { get; set; }
     }
