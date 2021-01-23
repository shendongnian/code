    internal class ListIndexable<T> : IIndexable<T>
    {
       private List<T> list;
       public ListIndexable(List<T> list) { this.list = list; }
    
       public T this[int i] { get { return list[i]; } }
    
       public IEnumerator<T> GetEnumerator()
       {
          return list.GetEnumerator();
       }
    }
