     public class TestModel
      {
        public string name { get; set; }
        public TimeSpan TimeWorked { get; set; }
        public TestModel()
        {
            TimeWorked = new TimeSpan(3, 20, 0);
            name = "hello";
        }
    }
