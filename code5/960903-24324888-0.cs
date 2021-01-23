    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("ClassLibrary1.Car")]
    public class Car
    {
        public Car()
        {
            Name = "";
            Parts = new Parts();
        }
        public string Name { get; set; }
        public Parts Parts { get; set; }
    }
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("ClassLibrary1.Parts")]
    public class Parts : IList<string>
    {
        private List<string> _parts;
        public Parts()
        {
            _parts = new List<string>();
        }
        #region IList<string> Members
        public int IndexOf(string item)
        {
            return _parts.IndexOf(item);
        }
        public void Insert(int index, string item)
        {
            _parts.Insert(index, item);
        }
        public void RemoveAt(int index)
        {
            _parts.RemoveAt(index);
        }
        public string this[int index]
        {
            get
            {
                return _parts[index];
            }
            set
            {
                _parts[index] = value;
            }
        }
        #endregion
        #region ICollection<string> Members
        public void Add(string item)
        {
            _parts.Add(item);
        }
        public void Clear()
        {
            _parts.Clear();
        }
        public bool Contains(string item)
        {
            return _parts.Contains(item);
        }
        public void CopyTo(string[] array, int arrayIndex)
        {
            _parts.CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get { return _parts.Count; }
        }
        public bool Remove(string item)
        {
            return _parts.Remove(item);
        }
        #endregion
        #region ICollection<string> Members
        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }
        #endregion
        #region IEnumerable<string> Members
        public IEnumerator<string> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
