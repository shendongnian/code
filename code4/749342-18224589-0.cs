    class mymodel : IComparable<mymodel>
    {
        public string AMPM { get; set; }
        public int System.IComparable<mymodel>.CompareTo(mymodel other)
        {
            int MyVal = AMPM == "AM" ? 1 : AMPM == "PM" ? 2 : AMPM == "MIX" ? 3 : 4;
            int OtherVal = other.AMPM == "AM" ? 1 : other.AMPM == "PM" ? 2 : other.AMPM == "MIX" ? 3 : 4;
            return MyVal.CompareTo(OtherVal);
     }
