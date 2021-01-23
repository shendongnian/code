    public interface IDoIt
    {
        void DoIt();
    }
    public class Foo : IDoIt
    {
        public void DoSomething()
        {
            
        }
        public void DoIt()
        {
            this.DoSomething();
        }
    }
    public class Bar : IDoIt
    {
        public void DoSomethingElse()
        {
            
        }
        public void DoIt()
        {
            this.DoSomethingElse();
        }
    }
    public class GenericClass<T> where T: IDoIt, new ()
    {
        public GenericClass()
        {
            T obj = new T();
            obj.DoIt();
        }
    }
