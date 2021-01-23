    class SomeClass
    {
        private int x = 42;
        public void DoSometing(int y)
        {
            int a = y + 5;
            x += a * a;
            // a stops to exist here
        }
    }
