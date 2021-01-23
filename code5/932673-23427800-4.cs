    public class Foo
    {
        public void DoSomething()
        {
    		dynamic thisDynamic = this;
            DoSomething(thisDynamic);
        }
    
        private static void DoSomething<T>(T obj)
        {
            var generic = new Generic<T>();
        }
    }
