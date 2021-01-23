    public class SomeClass
    {
        public DateTime ValidFrom { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime ExpirationDate
        {
            get { return this.ValidFrom + this.Duration; }
        }
    }
