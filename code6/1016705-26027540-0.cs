    public class Flight
    {
        [Key,  Column(Order = 1)]
        public int id { get; set; }
        public int route { get; set; }
        public String  flightDay { get; set; } 
        public int aircraft { get; set; }
    
        [NotMapped]
        public FlightDays FlightDayEnum
        {
            get
            {
                FlightDays day;
                Enum.TryParse<FlightDays>(flightDay, out day);
                return day;
            }
        }
    
       }
    
        public enum FlightDays
        {
            Monday,
            Tuesday,
            Wendsday,
            Thursday,
            Friday,
            Saturday,
            Sunday
         }
