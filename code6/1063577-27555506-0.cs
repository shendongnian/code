    class MyClassComparer : IEqualityComparer<MyClass>
    {
        public bool Equals(MyClass m1, MyClass m2)
        {
            return m1.KeyEquals(m2);
        }
        public int GetHashCode(MyClass m)
        {
           return (m.P1.GetHashCode() *23 ) + (m.P2.GetHashCode() * 17);
        } 
    }
