    namespace B
    {
        public class BClass : A.AClass
        {
            public **static** void Go()
            {
                A.AClass.MethodCall();
            }
        }
    }
 
