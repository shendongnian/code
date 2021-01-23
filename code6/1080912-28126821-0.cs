    public abstract class Meter
    {
        public int MeterId { get; set; }
        public string EANNumber { get; set; }
        public string MeterNumber { get; set; }
        public int PremiseId { get; set; }
        public abstract void AddReading(CounterReading reading);
    }
    
    
