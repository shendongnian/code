    public class Foo
    {
        public virtual void DoSomething()
        {
            DoSomething(this);
        }
    
        //notice this is protected now so it's accessible to `Bar`
        protected static void DoSomething<T>(T obj)
        {
            var generic = new Generic<T>();
        }
    }
    
    public class Bar : Foo
    {
        public override void DoSomething()
        {
            DoSomething(this);
        }
    }
