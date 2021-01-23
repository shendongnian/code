    public class MyEnumerable<TEntity> : IEnumerable<TEntity> where TEntity : class, new()
    {
        private Entity _lastElement;
        public IEnumerator<TEntity> GetEnumerator()
        {
            TEntity nextElement = // get next element based on _lastElement from database
            // check if a next element exists
            if (nextElement != null)
            {
                _lastElement = nextElement;
                yield return _lastElement;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
