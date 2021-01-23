    public class TestObject
    {
        public int id { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public TestObject(string value)
        {
            var valueSplit = value.Split('|');
            id = int.Parse(valueSplit[0]);
            status = valueSplit[1];
            type = valueSplit[2];
        }
    }
