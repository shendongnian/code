    public class MyContainer
    {
        public MyContainer()
        {
            this.Dictionary = new Dictionary<MyValue, int>();
        }
        public MyValue MyValue { get; set; }
        public Dictionary<MyValue, int> Dictionary { get; set; }
    }
