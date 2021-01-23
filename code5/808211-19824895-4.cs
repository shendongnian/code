    public static EnumerableExtensions
    {
        public static BufferEnumerable<T> Buffer(this IEnumerable<T> source)
        {
            return new BufferEnumerable<T>(source);
        }
    }
    public class BufferEnumerable<T> : IEnumerable<T>, IDisposable
    {
        IEnumerator<T> source;
        List<T> buffer;
        public BufferEnumerable(IEnumerable<T> source)
        {
            this.source = source.GetEnumerator();
            this.buffer = new List<T>();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new BufferEnumerator<T>(source, buffer);
        }
        public void Dispose()
        {
            source.Dispose()
        }
    }
    
    public class BufferEnumerator<T> : IEnumerator<T>
    {
        IEnumerator<T> source;
        List<T> buffer;
        int i = -1;
        public BufferEnumerator(IEnumerator<T> source, List<T> buffer)
        {
            this.source = source;
            this.buffer = buffer;
        }
        public T Current
        {
            get { return buffer[i]; }
        }
        public bool MoveNext()
        {
            i++;
            if (i < buffer.Count)
                return true;
            if (!source.MoveNext())
                return false;
            buffer.Add(source.Current);
            return true;
        }
        public void Reset()
        {
            i = -1;
        }
        public void Dispose()
        {
        }
    }
