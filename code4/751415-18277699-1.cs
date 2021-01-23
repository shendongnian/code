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
            if (A != null)
            {
                foreach (Action action in (A as MulticastDelegate).GetInvocationList().Reverse())
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
