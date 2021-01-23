    public class MyDataContext
    {
        public MyDataContext()
        {
            PlainText1 = "This is";
            LinkText = "some link";
            PlainText2 = "with text";
            ColorText = "and red color :)";
        }
        public string LinkText { get; set; }
        public string ColorText { get; set; }
        public string PlainText1{ get; set; }
        public string PlainText2 { get; set; }
    }
