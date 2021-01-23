    public class MyData
    {
        public byte FirstValue { get; set; }
        public int SecondValue { get; set; }
        public int ThirdValue { get; set; }
    }
    // serialize to string example
    var myData = new MyData { FirstValue = 2, SecondValue = 5, ThirdValue = -1 };
    string serialized = JsonConvert.SerializeObject(myData);
