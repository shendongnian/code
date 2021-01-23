    public class Test
    {
        public interface ISomeClass { }
    
        public class ImplementsSomeClass : ISomeClass { }
    
        public delegate void GenericDelegate<T>() where T : ISomeClass;
    
        public void GenericMethod<T>() { }
    
        public void CheckDelegate(GenericDelegate<ISomeClass> mechanism) { }
    
        public void test()
        {
            GenericDelegate<ISomeClass> someDelegate = GenericMethod<ImplementsSomeClass>;
            CheckDelegate(someDelegate);
        }
    }
