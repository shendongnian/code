    abstract class DoSomething
    {
        public Action DoWhateverItIsThatIDo { get; set; }
        protected DoSomething() { DoWhateverItIsThatIDo = DoSomething.DoIt; }
        protected DoSomething(Action whatAction)
        {
            DoWhateverItIsThatIDo = whatAction;
        }
        protected static void DoIt()
        {
            Console.WriteLine("You asked the abstract class to work. Too bad.");
        }
    }
    class InspireMe : DoSomething
    {
        public InspireMe() : base(InspireMe.DoIt) { }
        private static void DoIt()
        {
            Console.WriteLine("You are amazing.");
        }
    }
    class InsultMe : DoSomething
    {
        public InsultMe() : base(InsultMe.DoIt) { }
        private static void DoIt()
        {
            Console.WriteLine("You aren't worth it.");
        }
    }
    class DoWhatBaseClassDoes : DoSomething
    {
        public DoWhatBaseClassDoes() : base() {}
    }
    class Program
    {
        static void Main(string[] args)
        {
            DoSomething worker = new InsultMe();
            worker.DoWhateverItIsThatIDo();
            worker = new InspireMe();
            worker.DoWhateverItIsThatIDo();
            // In this case base class method is invoked
            worker = new DoWhatBaseClassDoes();
            worker.DoWhateverItIsThatIDo();
        }
    } 
