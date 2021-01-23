    public abstract class Foo 
    { 
        //general foo logic here
    }
    public class Foo<T>: Foo 
    { 
        //generic type specific information here
    }
    public class Bar
    {
        private List<Foo> foos = new List<Foo>();
        public Foo GetFoo(int index)
        {
            return foos[index];
        }
    }
