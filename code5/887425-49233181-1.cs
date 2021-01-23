    namespace B
    {
        public class BClass : A.AClass
        {
            public void Go()
            {
                A.AClass.MethodCall();
            }
        }
    }
 
