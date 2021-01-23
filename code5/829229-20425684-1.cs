    public interface ITry<T> : IEnumerable<T>
    {
        T Value { get; }
        ITry<U> SelectMany<U>(Func<T, ITry<U>> bindFunc);
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
            get { return false; }
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            yield break;
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
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
    
        public IEnumerator<T> GetEnumerator()
        {
            yield return this.Value;
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
    
    public static class Try
    {
        public static ITry<T> Failed<T>(Exception ex)
        {
            return new FailedTry<T>(ex);
        }
    
        public static ITry<T> Create<T>(Func<T> create)
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
    
        public static ITry<U> Select<T, U>(this ITry<T> @try, Func<T, U> mapFunc)
        {
            return @try.SelectMany(v => Create(() => mapFunc(v)));
        }
    }
