    interface IDoSomething
    {
        void DoWhateverItIsThatIDo();
    }
    class DoSomething : IDoSomething
    {
        private DoSomething() {}
        static readonly IDoSomething Instance;
        static DoSomething()
        {
            Instance = new DoSomething();
        }
        virtual void DoWhateverItIsThatIDo()
        {
            Console.WriteLine("You asked the abstract class to work. Too bad.");
        }
    }
    
    class InspireMe : IDoSomething
    {
        private InspireMe() {}
        static readonly IDoSomething Instance;
        static InspireMe()
        {
            Instance = new InspireMe();
        }
        override void DoWhateverItIsThatIDo()
        {
            Console.WriteLine("You are amazing.");
        }
    }
    
    class InsultMe : IDoSomething
    {
        private InsultMe() {}
        static readonly IDoSomething Instance;
        static InsultMe()
        {
            Instance = new InsultMe();
        }
        override void DoWhateverItIsThatIDo()
        {
            Console.WriteLine("You aren't worth it.");
        }
    }
    
    class Program
    {
        static void Main()
        {
            IDoSomething worker = InsultMe.Instance;
            worker.DoWhateverItIsThatIDo(); 
    
            worker = InspireMe.Instance;
            worker.DoWhateverItIsThatIDo();
        }
    }
