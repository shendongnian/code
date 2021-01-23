    public class MyClass
    {
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1);
        public DateTime MyDate { get; set; }
        [ScriptIgnore]
        public double EpochSeconds
        {
            get { return (MyDate - _epoch).TotalSeconds; }
            set { MyDate = _epoch.AddSeconds(value); }
        }
    }
