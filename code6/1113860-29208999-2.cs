    public class BaseClass
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
    public class DerivedClass : BaseClass
    {
        // Other fields and stuff over there
        //MethodoBeInherited should be available
        //MethodNotToBeInherited should not be available
    }
