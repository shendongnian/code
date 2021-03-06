    public class ListWrapper<TOut, TIn> : IList<TOut> where TIn : class, TOut where TOut : class 
    {
        readonly IList<TIn> list;
        public ListWrapper(IList<TIn> list)
        {
            if (list == null)
                throw new NullReferenceException();
            this.list = list;
        }
        #region IList<TOut> Members
        public int IndexOf(TOut item)
        {
            TIn itemIn = item as TIn;
            if (itemIn != item)
                return -1;
            return list.IndexOf(itemIn);
        }
        public void Insert(int index, TOut item)
        {
            list.Insert(index, (TIn)item);
        }
        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }
        public TOut this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = (TIn)value;
            }
        }
        #endregion
        #region ICollection<TOut> Members
        public void Add(TOut item)
        {
            list.Add((TIn)item);
        }
        public void Clear()
        {
            list.Clear();
        }
        public bool Contains(TOut item)
        {
            TIn itemIn = item as TIn;
            if (itemIn != item)
                return false;
            return list.Contains(itemIn);
        }
        public void CopyTo(TOut[] array, int arrayIndex)
        {
            foreach (var item in list)
            {
                array[arrayIndex] = item;
                arrayIndex++;
            }
        }
        public int Count
        {
            get { return list.Count; }
        }
        public bool IsReadOnly
        {
            get
            {
                return list.IsReadOnly;
            }
        }
        public bool Remove(TOut item)
        {
            return list.Remove(item as TIn);
        }
        #endregion
        #region IEnumerable<TOut> Members
        public IEnumerator<TOut> GetEnumerator()
        {
            foreach (var item in list)
                yield return item;
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
