    /// <summary>
    /// Array index range object
    /// </summary>
    public struct Index : IEnumerable<int>, ICloneable
    {
        readonly int[] index_list;
        public Index(params int[] indeces) { index_list=indeces; Array.Sort(index_list); }
        public Index(IEnumerable<int> indeces) { index_list=indeces.ToArray(); Array.Sort(index_list); }
        public static Index Span(int start, int count, int stride=1)
        {
            int[] values=new int[count];
            for(int i=0; i<values.Length; i++)
            {
                values[i]=start+i*stride;
            }
            return new Index(values);
        }
        public static implicit operator Index(int index) { return new Index(index); }
        public static implicit operator Index(int[] indeces) { return new Index(indeces); }
        public static implicit operator int[](Index index) { return index.index_list; }
        public static Index operator&(Index i1, Index i2) { return new Index(i1.index_list.Concat(i2.index_list)); }
        public static Index operator|(Index i1, Index i2) { return i1&Span(i1.Max+1, i2.Min-i1.Max-1)&i2; }
        public int this[int index] { get { return index_list[index]; } }
        public int Count { get { return index_list.Length; } }
        public int[] this[Index index]
        {
            get { return index.Extract(index_list); }
        }
        public int Min { get { return index_list.Length>0?index_list[0]:-1; } }
        public int Max { get { return index_list.Length>0?index_list[index_list.Length-1]:-1; } }
        public T[] Extract<T>(T[] array)
        {
            T[] result=new T[index_list.Length];
            for(int i=0; i<index_list.Length; i++)
            {
                result[i]=array[index_list[i]];
            }
            return result;
        }
        public void Inject<T>(T[] array, T[] items)
        {
            for(int i=0; i<index_list.Length; i++)
            {
                array[index_list[i]]=items[i];
            }
        }
        #region IEnumerable
        public IEnumerator<int> GetEnumerator()
        {
            for(int i=0; i<index_list.Length; i++)
            {
                yield return index_list[i];
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
        #region ICloneable Members
        public Index Clone() { return new Index(this.index_list); }
        object ICloneable.Clone()
        {
            return Clone();
        }
        #endregion
    }
