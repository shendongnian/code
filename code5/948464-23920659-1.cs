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
        public static Array<T> operator&(Array<T> array1, Array<T> array2)
        {            
            return new Array<T>(array1.elements.Concat(array2.elements));
        }
        public T this[int index] { get { return elements[index]; } }
        public int Count { get { return elements.Length; } }
        public Array<T> this[Index index]
        {
            get { return index.Extract(elements); }
            set { index.Inject(elements, value); }
        }
        public R[] Apply<R>(Func<T, R> unary) { return elements.Select((e) => unary(e)).ToArray(); }
        public R[] Apply<T1, R>(Array<T1> other, Func<T, T1, R> binary) { return elements.Zip(other, binary).ToArray(); }
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
            for(int i=0; i<elements.Length; i++)
            {
                yield return elements[i];
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
        #region ICloneable Members
        public Array<T> Clone() { return new Array<T>(elements); }
        object ICloneable.Clone()
        {
            return Clone();
        }
        #endregion
    }
