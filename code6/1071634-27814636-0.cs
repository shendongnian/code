    namespace MyProgram
    {
        public class ParentClass
        {
            public int Normal()
            {
                return 1;
            }
        }
    
        public class childClass : ParentClass
        {
            Normal(); // which calls the method in Base class(ParentClass)
            //base.Normal(); //or this one in which base tells that the method is in base class
        } 
    }
