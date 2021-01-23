    public class AnonymousClosureClass
    {
        public string One { get; set; }
        public string Two { get; set; }
        public string Three { get; set; }
        public void AnonymousLambda(object a, EventArgs b)
        {
            TestMethod(One, Two, Three);
        }
    }
