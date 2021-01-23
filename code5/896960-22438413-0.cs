    public class TestModel
    {
        public List<Tuple<int, string>> Items { get; set; }
        public TestModel()
        {
            Items = new List<Tuple<int, string>>();
            Items.Add(new Tuple<int, string>(1, "a"));
            Items.Add(new Tuple<int, string>(2, "b"));
            Items.Add(new Tuple<int, string>(3, "c"));
            Items.Add(new Tuple<int, string>(4, "d"));
            Items.Add(new Tuple<int, string>(5, "e"));
            Items.Add(new Tuple<int, string>(6, "f"));
            Items.Add(new Tuple<int, string>(7, "g"));
        }
    }
