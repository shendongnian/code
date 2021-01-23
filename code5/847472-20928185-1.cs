    public class Wrapper : IInterface1, IInterface2
    {
        private readonly YourProblematicClass _C;
        public Wrapper(YourProblematicClass c)
        {
            _C = c;
        }
        public string YourProblematicMetho()
        {
 
            // probably call the problematic method through _C.
            // and fix the return value, or fix the parameters
            // or don't call it at all, re-doing whatever it does
        }
    }
