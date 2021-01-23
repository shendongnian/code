    class Range
    {
        public int FromNumber { get; set; }
        public int ToNumber { get; set; }
        public bool Intersects(Range range)
        {
            if ( this.FromNumber <= range.ToNumber )
            {
                return (this.ToNumber >= range.FromNumber);
            }
            else if ( this.ToNumber >= range.FromNumber )
            {
                return (this.FromNumber <= range.ToNumber);
            }
            return false;
        }
    }
    class RangeList : IList<Range>
    {
        private readonly IList<Range> innerList;
        #region Constructors
        public RangeList()
        {
            this.innerList = new List<Range>();
        }
        public RangeList(int capacity)
        {
            this.innerList = new List<Range>(capacity);
        }
        public RangeList(IEnumerable<Range> collection)
        {
            this.innerList = new List<Range>(collection);
        }
        #endregion
        private bool IsUniqueRange(Range range)
        {
            if ( range == null )
                throw new ArgumentNullException("range");
            return !(this.innerList.Any(range.Intersects));
        }
        private Range EnsureUniqueRange(Range range)
        {
            if ( !IsUniqueRange(range) )
            {
                throw new ArgumentOutOfRangeException("range", "The specified range overlaps with one or more other ranges in this collection.");
            }
            return range;
        }
        public Range this[int index]
        {
            get
            {
                return this.innerList[index];
            }
            set
            {
                this.innerList[index] = EnsureUniqueRange(value);
            }
        }
        public void Insert(int index, Range item)
        {
            this.innerList.Insert(index, EnsureUniqueRange(item));
        }
        public void Add(Range item)
        {
            this.innerList.Add(EnsureUniqueRange(item));
        }
        #region Remaining implementation details
        public int IndexOf(Range item)
        {
            return this.innerList.IndexOf(item);
        }
        public void RemoveAt(int index)
        {
            this.innerList.RemoveAt(index);
        }
        public void Clear()
        {
            this.innerList.Clear();
        }
        public bool Contains(Range item)
        {
            return this.innerList.Contains(item);
        }
        public void CopyTo(Range[] array, int arrayIndex)
        {
            this.innerList.CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get { return this.innerList.Count; }
        }
        public bool IsReadOnly
        {
            get { return this.innerList.IsReadOnly; }
        }
        public bool Remove(Range item)
        {
            return this.innerList.Remove(item);
        }
        public IEnumerator<Range> GetEnumerator()
        {
            return this.innerList.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.innerList.GetEnumerator();
        }
        #endregion
    }
