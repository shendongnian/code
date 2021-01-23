    sealed class MyComparer : IEqualityComparer<TestA>
    {
        public bool Equals(TestA x, TestA y)
        {
            if (x == null)
                return y == null;
            else if (y == null)
                return false;
            else
                return x.ProductID == y.ProductID && x.Category == y.Category;
        }
    
        public int GetHashCode(TestA obj)
        {
            return obj.ProductID.GetHashCode();
        }
    }
