    public class BufferedIterator<T> : IDisposable
    {
        List<T> buffer = new List<T>();
        IEnumerator<T> iterator;
    
        public BufferedIterator(IEnumerable<T> source)
        {
            iterator = source.GetEnumerator();
        }
    
        public T GetItemAt(int index)
        {
            if (buffer.Count > index) // if item is buffered
                return buffer[index]; // return it
            // or fill buffer with next items
            while(iterator.MoveNext() && buffer.Count <= index)        
                buffer.Add(iterator.Current);
            // if we have read all file, but buffer has not enough items
            if (buffer.Count <= index)
                throw new IndexOutOfRangeException(); // throw
        
            return buffer[index]; // otherwise return required item
        }
    
        public void Dispose()
        {
           if (iterator != null)
               iterator.Dispose();
        }
    }
