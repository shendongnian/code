    interface IDoSomething
    {
        void DoWhateverItIsThatIDo();
    }
    class DoSomething : IDoSomething
    {
        private DoSomething() {}
        internal static readonly IDoSomething Instance;
        static DoSomething()
        {
            Instance = new DoSomething();
        }
        public void DoWhateverItIsThatIDo()
        {
            Console.WriteLine("You asked the abstract class to work. Too bad.");
        }
    }
    
    class InspireMe : IDoSomething
    {
        private InspireMe() {}
        internal static readonly IDoSomething Instance;
        static InspireMe()
        {
            Instance = new InspireMe();
        }
        public void DoWhateverItIsThatIDo()
        {
            Console.WriteLine("You are amazing.");
        }
    }
    
    class InsultMe : IDoSomething
    {
        private InsultMe() {}
        internal static readonly IDoSomething Instance;
        static InsultMe()
        {
            Instance = new InsultMe();
        }
        public void DoWhateverItIsThatIDo()
        {
            Console.WriteLine("You aren't worth it.");
        }
    }
