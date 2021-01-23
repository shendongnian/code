    public class SomeClass<T> where T : MyBaseClass
    {
        public void Process(T instance)
        {
        }
    
        public void Process(IList<T> list)
        {
        }
    }
