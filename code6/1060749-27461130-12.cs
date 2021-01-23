    public class Events
    {
       public string Date {get; set;}
       public string Title {get; set;}
       public string Description {get; set;}
       public string Organizer {get; set;}
       public string Place {get; set;}
    }
    ....
    // This creates a new instance of an Events 
    Events tempe = new Events();
    tempe.Date = event_info[0];
    .....
