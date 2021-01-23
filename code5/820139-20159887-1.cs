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
            if (buffer.Count > index)
                return buffer[index];
    
            while(iterator.MoveNext() && buffer.Count <= index)        
                buffer.Add(iterator.Current);
            
            if (buffer.Count <= index)
                throw new IndexOutOfRangeException();
        
            return buffer[index];
        }
    
        public void Dispose()
        {
           if (iterator != null)
               iterator.Dispose();
        }
    }
