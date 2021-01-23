    public class MyClass
    {
        [JsonIgnore()]
        public string Value4 {get; set;}
        public int Value4AsInt
        {
            return Convert.ToInt32(Value4);
        }
    }
