    public class MyClass
    {
        [Editor(typeof(NoneEditor), typeof(UITypeEditor))]
        public string MyText { get; set; }
        public string MyOtherText { get; set; }
    }
