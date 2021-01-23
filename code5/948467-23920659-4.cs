    /// <summary>
    /// Generic Array object
    /// </summary>
    /// <typeparam name="T">The element type</typeparam>
    public class Array<T> : IEnumerable<T>, ICloneable
    {
        readonly T[] elements;
        public Array(int count) { this.elements=new T[count]; }
        public Array(params T[] elements) { this.elements=elements; }
        public Array(IEnumerable<T> elements) { this.elements=elements.ToArray(); }
        public static implicit operator Array<T>(T element) { return new Array<T>(element); }
        public static implicit operator Array<T>(T[] elements) { return new Array<T>(elements); }
        public static implicit operator T[](Array<T> array) { return array.elements; }
        /// <summary>
        /// Concatenate two arrays
        /// </summary>
        public static Array<T> operator&(Array<T> array1, Array<T> array2)
        {
            return new Array<T>(array1.elements.Concat(array2.elements));
        }
        /// <summary>
        /// Get a single element from the array
        /// </summary>
        public T this[int index]
        {
            get { return elements[index]; }
            set { elements[index]=value; }
        }
        public int Count { get { return elements.Length; } }
        /// <summary>
        /// Extract a sub-array based on the index range
        /// </summary>
        public Array<T> this[Index index]
        {
            get { return index.Extract(elements); }
            set { index.Inject(elements, value); }
        }
        /// <summary>
        /// Apply a transformation to the array
        /// </summary>
        public R[] Apply<R>(Func<T, R> unary) { return elements.Select((e) => unary(e)).ToArray(); }
        /// <summary>
        /// Combine two arrays using a binary operator
        /// </summary>
        public R[] Apply<T1, R>(Array<T1> other, Func<T, T1, R> binary) { return elements.Zip(other, binary).ToArray(); }
        /// <summary>
        /// Dynamic addition operator
        /// </summary>
        public static Array<T> operator+(Array<T> a, Array<T> b)
        {
            int N=Math.Max(a.Count, b.Count);
            T[] res=new T[N];
            for(int i=0; i<res.Length; i++)
            {
                res[i]=(dynamic)a[i%a.Count]+(dynamic)b[i%b.Count];
            }
            return res;
        }
        /// <summary>
        /// Dynamic subtraction operator
        /// </summary>
        public static Array<T> operator-(Array<T> a, Array<T> b)
        {
            int N=Math.Max(a.Count, b.Count);
            T[] res=new T[N];
            for(int i=0; i<res.Length; i++)
            {
                res[i]=(dynamic)a[i%a.Count]-(dynamic)b[i%b.Count];
            }
            return res;
        }
        /// <summary>
        /// Dynamic multiplication operator
        /// </summary>
        public static Array<T> operator*(Array<T> a, Array<T> b)
        {
            int N=Math.Max(a.Count, b.Count);
            T[] res=new T[N];
            for(int i=0; i<res.Length; i++)
            {
                res[i]=(dynamic)a[i%a.Count]*(dynamic)b[i%b.Count];
            }
            return res;
        }
        /// <summary>
        /// Dynamic division operator
        /// </summary>
        public static Array<T> operator/(Array<T> a, Array<T> b)
        {
            int N=Math.Max(a.Count, b.Count);
            T[] res=new T[N];
            for(int i=0; i<res.Length; i++)
            {
                res[i]=(dynamic)a[i%a.Count]/(dynamic)b[i%b.Count];
            }
            return res;
        }
        #region IEnumerable
        public IEnumerator<T> GetEnumerator()
        {
            for(int i=0; i<elements.Length; i++) { yield return elements[i]; }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
        #region ICloneable Members
        public Array<T> Clone() { return new Array<T>(elements); }
        object ICloneable.Clone() { return Clone(); }
        #endregion
    }
