    public class MyClass
    {
        public DateTime MyDate { get; set; }
        [ScriptIgnore]
        public int EpochSeconds
        {
            get { return (new DateTime(1970, 1, 1) - MyDate).TotalSeconds; }
            set { MyDate = (new DateTime(1970, 1, 1)).AddSeconds(value); }
        }
    }
