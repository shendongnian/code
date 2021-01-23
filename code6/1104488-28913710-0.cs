    public class TestClass
    {
        public string MyText { get; set; }
    }
    bool contained = MyList.Items.Cast<TestClass>().Any(x => x.MyText == "Test");
