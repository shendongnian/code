    // Proxy class for any enumerable with the requisite `Add` methods.
    public class EnumerableProxy<T> : IEnumerable<T>
    {
        [XmlIgnore]
        public IEnumerable<T> BaseEnumerable { get; set; }
        public void Add(T obj)
        {
            throw new NotImplementedException();
        }
        public void Add(System.Object obj)
        {
            throw new NotImplementedException();
        }
        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            if (BaseEnumerable == null)
                return Enumerable.Empty<T>().GetEnumerator();
            return BaseEnumerable.GetEnumerator();
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
