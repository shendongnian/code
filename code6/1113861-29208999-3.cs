    interface I
    {
        void MethodToBeInherited(string input)
    }
    
    class BaseClass
    {
        public void MethodToBeInherited(string input)
        {
            // Doing stuff here
        }
        public void MethodNotToBeInherited(string input)
        {
            // Doing stuff here
        }
    }
    
    class DerivedClass : I
    {
        public void MethodToBeInherited(string input)
        {
            b.MethodToBeInherited(input);
        }
    
        private BaseClass b;
    }
