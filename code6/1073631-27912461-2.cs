    public interface IMainInterface
    {
        IClass1 Value1 { get; set; }
        IList<IClass2> Value2 { get; set; }
    }
    [Serializable]
    [DataContract(Name = "MainClass")]
    public class MainClass : IMainInterface
    {
        [DataMember(Name = "class")]
        Class1 RealValue1 { get; set; }
        [DataMember(Name = "classes")]
        private List<Class2> RealList2 { get; set; }
        IList<IClass2> list2Proxy; // can't be readonly because the DataContactJsonSerializer does not call the default constructor.
        private IList<IClass2> List2Proxy
        {
            get
            {
                if (list2Proxy == null)
                    Interlocked.CompareExchange(ref list2Proxy, new ConvertingList<Class2, IClass2>(() => this.RealList2, c => c, ToClass), null);
                return list2Proxy;
            }
        }
        Class2 ToClass(IClass2 iClass)
        {
            // REWRITE TO FIT YOUR NEEDS
            return (Class2)iClass;
        }
        Class1 ToClass(IClass1 iClass)
        {
            // REWRITE TO FIT YOUR NEEDS
            return (Class1)iClass;
        }
        public MainClass()
        {
            RealList2 = new List<Class2>();
        }
        [IgnoreDataMember]
        public IClass1 Value1
        {
            get
            {
                return RealValue1;
            }
            set
            {
                RealValue1 = ToClass(value);
            }
        }
        [IgnoreDataMember]
        public IList<IClass2> Value2
        {
            get
            {
                return List2Proxy;
            }
            set
            {
                if (value == null)
                {
                    RealList2.Clear();
                    return;
                }
                if (List2Proxy == value)
                    return;
                RealList2 = value.Select<IClass2, Class2>(ToClass).ToList();
            }
        }
    }
    public class ConvertingList<TIn, TOut> : IList<TOut>
    {
        readonly Func<IList<TIn>> getList;
        readonly Func<TIn, TOut> toOuter;
        readonly Func<TOut, TIn> toInner;
        public ConvertingList(Func<IList<TIn>> getList, Func<TIn, TOut> toOuter, Func<TOut, TIn> toInner)
        {
            if (getList == null || toOuter == null || toInner == null)
                throw new ArgumentNullException();
            this.getList = getList;
            this.toOuter = toOuter;
            this.toInner = toInner;
        }
        IList<TIn> List { get { return getList(); } }
        TIn ToInner(TOut outer) { return toInner(outer); }
        TOut ToOuter(TIn inner) { return toOuter(inner); }
        #region IList<TOut> Members
        public int IndexOf(TOut item)
        {
            return List.IndexOf(toInner(item));
        }
        public void Insert(int index, TOut item)
        {
            List.Insert(index, ToInner(item));
        }
        public void RemoveAt(int index)
        {
            List.RemoveAt(index);
        }
        public TOut this[int index]
        {
            get
            {
                return ToOuter(List[index]);
            }
            set
            {
                List[index] = ToInner(value);
            }
        }
        #endregion
        #region ICollection<TOut> Members
        public void Add(TOut item)
        {
            List.Add(ToInner(item));
        }
        public void Clear()
        {
            List.Clear();
        }
        public bool Contains(TOut item)
        {
            return List.Contains(ToInner(item));
        }
        public void CopyTo(TOut[] array, int arrayIndex)
        {
            foreach (var item in this)
                array[arrayIndex++] = item;
        }
        public int Count
        {
            get { return List.Count; }
        }
        public bool IsReadOnly
        {
            get { return List.IsReadOnly; }
        }
        public bool Remove(TOut item)
        {
            return List.Remove(ToInner(item));
        }
        #endregion
        #region IEnumerable<TOut> Members
        public IEnumerator<TOut> GetEnumerator()
        {
            foreach (var item in List)
                yield return ToOuter(item);
        }
        #endregion
        #region IEnumerable Members
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
