    public class DisposableList : List<IDisposable>, IDisposable
    {
        public void Dispose()
        {
            if (this.Count > 0)
            {
                List<Exception> exceptions = new List<Exception>();
            
                foreach(var disposable in this)
                {
                    try
                    {
                        disposable.Dispose();
                    }
                    catch (Exception e)
                    {
                        exceptions.Add(e);
                    }
                }
                base.Clear();
            
                if (exceptions.Count > 0)
                    throw new AggregateException(exceptions);
            }
        }
        
        public T Add<T>(Func<T> factory) where T : IDisposable
        {
            var item = factory();
            base.Add(item);
            return item;
        }
    }
