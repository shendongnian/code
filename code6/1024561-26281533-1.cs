    public struct MyEnumCOmparer : IEqualityComparer<MyEnum>
    {
        public bool Equals(MyEnum x, MyEnum y)
        {
            return x == y;
        }
    
        public int GetHashCode(MyEnum obj)
        {
            return obj.GetHashCode();
        }
    }
