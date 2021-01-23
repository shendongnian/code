    public class Appointment
    {
    
         private Appointment(string name, DateTime app, int id)
         {
             Name = name;
             Time = app;
             Id = id;
         }
    
         public string Name {get ; private set;}
         public DateTime Time{get; private set;}
         public int Id{get ;private set;} // Not sure if the 11 was an id or the time in your example.
    
         public static Create(string name, DateTime app, int id)
         {
            return new Appointment(name,app, id);
         } 
    }
