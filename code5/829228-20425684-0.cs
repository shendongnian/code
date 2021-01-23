    public interface ITry<T>
    {
        T Value { get; }
        public ITry<U> SelectMany<U>(Func<T, ITry<U>> bindFunc);
        bool IsSuccess { get; }
    }
    
    public class FailedTry<T> : ITry<T>
    {
        private readonly Exception ex;
        public FailedTry(Exception ex)
        {
            this.ex = ex;
        }
    
        public T Value
        {
            get { throw new InvalidOperationException("Can't get value for failed Try"); }
        }
    
        public ITry<U> SelectMany<U>(Func<T, ITry<U>> bindFunc)
        {
            return new FailedTry<U>(this.ex);
        }
    
        public bool IsSuccess
        {
            get { return false; ; }
        }
    }
    
    public class SuccessTry<T> : ITry<T>
    {
        public SuccessTry(T value)
        {
            this.Value = value;
        }
    
        public T Value { get; private set; }
    
        public ITry<U> SelectMany<U>(Func<T, ITry<U>> bindFunc)
        {
            if (bindFunc == null) return new FailedTry<U>(new ArgumentNullException("bindFunc"));
            try
            {
                return bindFunc(this.Value);
            }
            catch (Exception ex)
            {
                return new FailedTry<U>(ex);
            }
        }
    
        public bool IsSuccess
        {
            get { return true; }
        }
    }
    
    public static class Try
    {
        public ITry<T> Failed<T>(Exception ex)
        {
            return new FailedTry<T>(ex);
        }
    
        public ITry<T> Create<T>(Func<T> create)
        {
            if (create == null) return new FailedTry<T>(new ArgumentNullException("create"));
            try
            {
                return new SuccessTry<T>(create());
            }
            catch (Exception ex)
            {
                return new FailedTry<T>(ex);
            }
        }
    }
