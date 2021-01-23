        public class Counter
    {
        private readonly ObservableCollection<CounterReading> readings = new ObservableCollection<CounterReading>();
        public virtual ObservableCollection<CounterReading> Readings
        {
            get { return readings; }
            set { readings = value; }
        }
        [Key, ForeignKey("Meter")]
        public int CounterId { get; set; }
        public virtual Meter Meter { get; set; }
        [NotMapped]
        public CounterReading CurrentReading
        {
            get
            {
                if (Readings.Count > 0)
                {
                    return Readings.MaxBy(m => m.Reading);
                }
                return null;
            }
        }
    }
