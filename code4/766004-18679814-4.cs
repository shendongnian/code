    class Program
    {
        interface IState
        {
        }
        class State1 : IState
        {
        }
        class State2 : IState
        {
        }
        private static void UpdateState(State1 s1)
        {
            Console.WriteLine("State1 Updated.");
        }
        private static void UpdateState(State2 s1)
        {
            Console.WriteLine("State2 Updated.");
        }
        static void Main(string[] args)
        {
            var random = new Random(123456);
            var i = 10;
            while (i-- > 0)
            {
                var n = random.Next();
                dynamic curStep = (n % 2) == 0 ? (dynamic)new State1() : new State2();
                UpdateState(curStep);
            }
            Console.ReadKey();
        }
    }
