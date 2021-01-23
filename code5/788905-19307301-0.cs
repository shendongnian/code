    public class MutatingSource<T> : IEnumerable<T>
    {
         public MutatingSource(IEnumerable<T> originalSource)
         {
             this.Source = originalSource;
         }
         public IEnumerable<T> Source { get; set; }
         IEnumerator IEnumerable.GetEnumerator()
         {
             return this.GetEnumerator();
         }
         public IEnumerator<T> GetEnumerator()
         {
            return Source.GetEnumerator();
         }
    }
