    public class DLL<T> : IEnumerable<T>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException("Need to implement");
        }
        
        // Compose, not inherit
        public IEnumerable<DLLItem<T>> DLLItems
        {
            get
            {
                throw new NotImplementedException("Need to implement");
            }
        }
    }
