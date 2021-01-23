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
        interface IAction
        {
        }
        class SomeAction : IAction
        {
        }
        private static void UpdateState(IAction act, State1 s1)
        {
            Console.WriteLine("State1 IAction Updated.");
        }
        private static void UpdateState(SomeAction act, State2 s1)
        {
            Console.WriteLine("State2 SomeAction Updated.");
        }
        static void Main(string[] args)
        {
            var random = new Random(123456);
            var i = 10;
            IAction act = new SomeAction();
            while (i-- > 0)
            {
                var n = random.Next();
                dynamic curStep = (n % 2) == 0 ? (dynamic)new State1() : new State2();
                if (curStep is State1)
                    UpdateState(act, curStep);
                else if (curStep is State2)
                    UpdateState(act, curStep);
            }
            Console.ReadKey();
        }
    }
