    public class Test
    {
        public interface ISomeClass { }
    
        public class ImplementsSomeClass : ISomeClass { }
    
        public delegate void GenericDelegate<T>() where T : ISomeClass;
    
        public void GenericMethod<T>() 
        {
            // EDIT: returns typeof(ImplementsSomeClass)
            var t = typeof(T); 
        }
    
        public void CheckDelegate(GenericDelegate<ISomeClass> mechanism)
        {
            // EDIT: call without generic argument since it is already determined 
            mechanism(); 
        }
    
        public void test()
        {
            GenericDelegate<ISomeClass> someDelegate = GenericMethod<ImplementsSomeClass>;
            CheckDelegate(someDelegate);
        }
    }
