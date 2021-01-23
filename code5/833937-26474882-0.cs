    public class InterfaceCollectionAdapter<TConcrete, TInterface> : ICollection<TInterface> where TConcrete : TInterface
    {
        private Func<ICollection<TConcrete>> _gettor;
        private ICollection<TConcrete> Wrapped
        {
            get
            {
                return _gettor();
            }
        }
        public InterfaceCollectionAdapter(Func<ICollection<TConcrete>> gettor)
        {
            _gettor = gettor;
        }
        public void Add(TInterface item)
        {
            Wrapped.Add((TConcrete)item);
        }
        public void Clear()
        {
            Wrapped.Clear();
        }
        public bool Contains(TInterface item)
        {
            return Wrapped.Contains((TConcrete)item);
        }
        public void CopyTo(TInterface[] array, int arrayIndex)
        {
            var wrapped = Wrapped;
            foreach (var item in wrapped)
            {
                array[arrayIndex++] = (TInterface)item;
            }
        }
        public int Count
        {
            get { return Wrapped.Count; }
        }
        public bool IsReadOnly
        {
            get { return Wrapped.IsReadOnly; }
        }
        public bool Remove(TInterface item)
        {
            return Wrapped.Remove((TConcrete)item);
        }
        public IEnumerator<TInterface> GetEnumerator()
        {
            var wrapped = Wrapped;
            foreach (var item in wrapped)
                yield return item;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
