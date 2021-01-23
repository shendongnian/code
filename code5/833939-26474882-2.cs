    public class InterfaceCollectionAdapter<TConcrete, TInterface> : ICollection<TInterface> where TConcrete : TInterface
    {
        private Func<ICollection<TConcrete>> _gettor;
        private Action<ICollection<TConcrete>> _settor;
        private Func<ICollection<TConcrete>> _factory;
        private ICollection<TConcrete> Wrapped
        {
            get
            {
                var value = _gettor();
                if (value == null && _settor != null)
                {
                    value = (_factory != null)
                        ? _factory()
                        : new List<TConcrete>();
                    _settor(value);
                }
                return value;
            }
        }
        public InterfaceCollectionAdapter(Func<ICollection<TConcrete>> gettor, Action<ICollection<TConcrete>> settor = null, Func<ICollection<TConcrete>> factory = null)
        {
            _gettor = gettor;
            _settor = settor;
            _factory = factory;
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
