    public class Wrapper<T> : ICollection<object>
    {
        private readonly ICollection<T> collection;
        public Wrapper(ICollection<T> collection)
        {
            this.collection = collection;
        }
        public void Add(object item)
        {
            // maybe check if T is of the desired type
            collection.Add((T)item);
        }
        public void Clear()
        {
            collection.Clear();
        }
        public bool Contains(object item)
        {
            // maybe check if T is of the desired type
            return collection.Contains((T)item);
        }
        public void CopyTo(object[] array, int arrayIndex)
        {
            // maybe check if T is of the desired type
            collection.CopyTo(array.Cast<T>().ToArray(), arrayIndex);
        }
        public int Count
        {
            get { return collection.Count; }
        }
        public bool IsReadOnly
        {
            get { return collection.IsReadOnly; }
        }
        public bool Remove(object item)
        {
            // maybe check if T is of the desired type
            return collection.Remove((T)item);
        }
        public IEnumerator<object> GetEnumerator()
        {
            yield return collection;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return collection.GetEnumerator();
        }
    }
