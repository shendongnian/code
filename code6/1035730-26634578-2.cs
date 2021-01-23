    public class Program
    {
        private static void Main(string[] args)
        {
            TestableProgram2 tp = new TestableProgram2();
            tp.b_PropertyChanged(new Program(), "bang");
        }
    }
    public class Program2
    {
        protected void b_PropertyChanged(object sender, string e)
        {
            Debug.Write(e);
        }
    }
    public class TestableProgram2 : Program2
    {
        public new void b_PropertyChanged(object sender, string e)
        {
             e = "altered";       // here to demonstrate this code is entered.
            base.b_PropertyChanged(sender, e);
        }
    }
