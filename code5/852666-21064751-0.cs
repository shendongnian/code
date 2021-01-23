    public class Derived<T> : Base, IDisposable where T : IDisposable, new()
    {
        public Derived()
            : base(new T())
        {
        }
        public void Dispose()
        {
            var obj = base._object as IDisposable;
            if (obj != null)
                obj.Dispose();
        }
    }
