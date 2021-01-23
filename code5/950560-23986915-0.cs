    class YourObject
    {
        public DateTime Date {get; set;}
        public TimeSpan TimeUntilDate
        {
            get {return Date - DateTime.Now;}
        }
    }
