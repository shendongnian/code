    public class Ride
    {
        public Destination {get; set;}
        public Arrival {get;set;}
        .... 
    
        public bool IsValid()
        {
            if (Arrival == null)
            {
                throw new ArgumentException("Arrival");
            }
            return DoSomethingToValidateDestionationAndArrival();
        }
    }
