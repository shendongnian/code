    class Program
    {
        public delegate Task<T> MyFunc<T>();
    
        public Task<MyClass> ff(MyFunc<MyClass> f)
        {
            return f();
        }
    
        public void aa()
        {
            ff(() => Task.Run(() => new MyClass()));
        }
    
    }
    
    
    
    public class MyClass
    {
        public MyClass() { }
    }
