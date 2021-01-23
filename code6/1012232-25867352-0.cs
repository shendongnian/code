    public class SomeClass
    {
        private static readonly object _lock = new object();
            
        public void SomeMethod()
        {
           lock (_lock)
           {
               // some code
           }
        }
    }
