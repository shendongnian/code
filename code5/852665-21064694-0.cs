    public class DisposeMe : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("I'm disposed!");
        }
    }
    public class Base
    {
        private readonly Object _object;
        protected Object _Object { get { return _object; } }
        public Base(Object obj)
        {
            _object = obj;
        }
    }
    public class Derived : Base, IDisposable
    {
        public Derived()
            : base(new DisposeMe())
        {
        }
        public void Dispose()
        {
            (_Object as IDisposable).Dispose();
        }
    }
