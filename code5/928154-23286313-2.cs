    public abstract class AbstractProcessor<T>
    {
        public void ProcessData(List<T> data)
        {
            var exceptions = new List<Exception>();
            foreach (var item in data)
            {
                try
                {
                    ProcessDataInternal(item);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                }
            }
            if (exceptions.Count > 0) throw new AggregateException(exceptions);
        }
        protected abstract void ProcessDataInternal(T data);
    }
