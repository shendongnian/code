    public class MyProxy<T> : RealProxy where T : class
    {
        private T _target;
    
        public MyProxy(T target) :
            base(CombineType(typeof(T), typeof(IDisposable)))
        {
            this._target = target;
        }
