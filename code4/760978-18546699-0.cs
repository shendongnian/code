    public class MyClassEqualityComparer : IEqualityComparer<MyClass>
    {
        private static Lazy<MyClassEqualityComparer> _instance = new Lazy<MyClassEqualityComparer>(() => new MyClassEqualityComparer());
        public static MyClassEqualityComparer Instance
        {
            get { return _instance.Value; }
        }
        private MyClassEqualityComparer() { }
        public bool Equals(MyClass x, MyClass y)
        {
            return x.val1 == y.val1 && x.val2 == y.val2 && x.val3 == y.val3;
        }
        public int GetHashCode(MyClass obj)
        {
            return obj.val1.GetHashCode() ^ obj.val2.GetHashCode() ^ obj.val3.GetHashCode();
        }
    }
