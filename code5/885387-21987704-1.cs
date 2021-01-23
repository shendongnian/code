        public class BaseClass{}
    
        public class SubClass1 : BaseClass  
        {
            public void SomeMethod1()
            {
            }
        }
    
        public class SubClass2 : BaseClass  
        {
            public void SomeMethod2()
            {
            }
        }
    
        public class Class1
        {
            public Class1()
    	    {
                var test = new SubClass1();
    
                var lookup = new Dictionary<Type, Action<object>>
                                 {
                                     {typeof (SubClass1), o => ((SubClass1) o).SomeMethod1() },
                                     {typeof (SubClass2), o => ((SubClass2) o).SomeMethod2() }
                                 };
    
                //probably best to check the type exists in the dictionary first, 
                //maybe wrap up the execution into a class of it's own so it's abstracted away
                lookup[test.GetType()](test);
    
    	    }
        }
