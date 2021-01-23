    public class E : User
    {
        public string MiddleInitial { get; set; }
        public override string Data { get { return MiddleInitial; } }
    }
    public class F : User
    {
        public string LastName { get; set; }
        public override string Data { get { return LastName; } }
    }
