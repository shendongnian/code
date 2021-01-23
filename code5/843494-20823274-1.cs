    // Alpha.DLL
    public class First 
    { 
        internal int myVariable;
    }
    public class Second : First
    {
        public Second() { myVariable = 123; } // Legal!
    }
    
    // Bravo.DLL
    class Third : Second
    {
        public Third() { myVariable = 456; } // Illegal!
    }
    
