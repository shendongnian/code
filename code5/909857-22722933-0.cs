     class FlatCollection<T> : IEnumerable<T>
     {
        List<IEnumerable<T>> list = new ...
      
        public Add(T item) { list.Add(Enumerable.Repeat(item, 1);}
        public Add(IEnumerable<T> item) { list.Add(item);}
        
        // use Enumerable.SelectMany to imeplent IEnumerable
      }
