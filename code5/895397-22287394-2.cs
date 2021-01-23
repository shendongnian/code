    public class MyClass
    {
        public string m_x;
        public string m_y;
        public MyClass(string x, string y)
        {
            m_x = x;
            m_y = y;
        }
    }
    public class MyEqualityComparer : IEqualityComparer<MyClass>
    {
        public bool Equals(MyClass x, MyClass y)
        {
            return x.m_x == y.m_x && x.m_y == y.m_y;
        }
        public int GetHashCode(MyClass obj)
        {
            return obj.m_x.GetHashCode() ^ obj.m_y.GetHashCode();
        }
    }
