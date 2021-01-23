    public enum Day { Monday = 1, Tuesday =2, ... }
    
    [Table("flight")]
    public class Flight
    {
        [Key,  Column(Order = 1)]
        public int id { get; set; }
        public int route { get; set; }
        public int flightDayId { get; set; } 
        
        // Provides enum abstraction for flightDayId
        public Day FlightDay { 
          get { return (Day)flightDayId; } 
          set { flightDayId = (int)value; }
        }
        public int aircraft { get; set; }
    
    }
