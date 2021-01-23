    class First
    {
        private int myVariable;
        public class Second : First
        {
            public Second() { myVariable = 123; } // Legal!
        }
    }
    class Third : First.Second
    {
        public Third() { myVariable = 456; } // Illegal!
    }
