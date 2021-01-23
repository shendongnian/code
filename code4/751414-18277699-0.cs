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
        private Action M1()
        {
            // Do work.
            return M2;
        }
        private void M2()
        {
            if (B != null)
                B();
        }
    }
