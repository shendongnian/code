    public class AnonymousClosureClass
    {
        public Func<string> One { get; set; }
        public Func<string> Two { get; set; }
        public Func<string> Three { get; set; }
        public void AnonymousLambda(object a, EventArgs b)
        {
            TestMethod(One(), Two(), Three());
        }
    }
