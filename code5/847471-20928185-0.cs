    public class YourFixedClass : TheProblematicClass
    {
        public override string YourProblematicMethod()
        {
            // probably call the problematic method through base.
            // and fix the return value, or fix the parameters
            // or don't call it at all, re-doing whatever it does
        }
    }
