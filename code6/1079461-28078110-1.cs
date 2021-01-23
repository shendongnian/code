    abstract class DoSomething
    {
        public Action whatToDo { get; set; }        
        protected DoSomething() { 
           whatToDo = DoSomething.DoWhateverItIsThatIDo; 
        }
        protected DoSomething(Action whatAction)
        {
            whatToDo = whatAction;
        }
        protected static void DoWhateverItIsThatIDo()
        {
            Console.WriteLine("You asked the abstract class to work. Too bad.");
        }
    }
    class InspireMe : DoSomething
    {
        public InspireMe() : base(InspireMe.DoWhateverItIsThatIDo) { }
        private static void DoWhateverItIsThatIDo()
        {
            Console.WriteLine("You are amazing.");
        }
    }
    class InsultMe : DoSomething
    {
        public InsultMe() : base(InsultMe.DoWhateverItIsThatIDo) { }
        private static void DoWhateverItIsThatIDo()
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
            worker.whatToDo();
            worker = new InspireMe();
            worker.whatToDo();
            // In this case the base class method is invoked
            worker = new DoWhatBaseClassDoes();
            worker.whatToDo();
        }
    } 
