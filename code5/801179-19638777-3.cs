    public class MyOtherEqualityComparer : IEqualityComparer<object>
    {
        private object GetProperty(object obj)
        {
            if (obj is TypeA)
                return ((TypeA)obj).PropA;
            else if (obj is TypeB)
                return ((TypeB)obj).PropB;
            else
                throw new Exception();
        }
        public bool Equals(object a, object b)
        {
            return GetProperty(a).Equals(GetProperty(b));
        }
        public int GetHashCode(object obj)
        {
            return GetProperty(obj).GetHashCode();
        }
    }
