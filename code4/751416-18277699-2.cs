    public class EventThing
    {
        public event Action A;
        public event Action B;
        public EventThing()
        {
            A += () =>
            {
                Action next = M1();
                if (next != null)
                    next();
            };
        }
        public void FireA()
        {
            var AHandlers = A;
            if (AHAndlers != null)
            {
                foreach (Action action in (AHAndlers as MulticastDelegate).GetInvocationList().Reverse())
                    action();
            }
        }
        private Action M1()
        {
            Console.WriteLine("Running M1");
            return M2;
        }
        private void M2()
        {
            Console.WriteLine("Running M2");
            if (B != null)
                B();
        }
    }
    static void Main(string[] args)
    {
        var eventThing = new EventThing();
        eventThing.A += () => Console.WriteLine("Performing A");
        eventThing.B += () => Console.WriteLine("Performing B");
        eventThing.FireA();
        Console.ReadLine();
    }
