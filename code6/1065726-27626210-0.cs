    class Reading
    {
        public int Id { get; set; }
        public DateTime TimestampLocal { get; set; }
        public double Value { get; set; }
        public int Meter_Id { get; set; }
    }
    List<Reading> Readings = new List<Reading>()
    {
        new Reading { Id = 1, TimestampLocal = new DateTime(2014, 8, 22), Value = 50.5, Meter_Id = 1 },
        new Reading { Id = 2, TimestampLocal = new DateTime(2013, 8, 12), Value = 30.2, Meter_Id = 1 },
        new Reading { Id = 3, TimestampLocal = new DateTime(2013, 9, 12), Value = 35.2, Meter_Id = 1 }
    };
