    void Main()
    {
    
    }
    
    public class ClassA
    {
        public ClassA(out bool success)
        {
            success = true;
        }
    }
    
    public class B: ClassA
    {
        private static bool success;
    
        // call the constructor from ClassA but without the out-param
        public B()
            : base(out success)
        {
        }
    }
