    public class IdComparer : IEqualityComparer<CustomObject>
    {
        public int GetHashCode(CustomObject co)
        {
            if (co == null)
            {
                return 0;
            }
            return co.Id.GetHashCode();
        }
    
        public bool Equals(CustomObject x1, CustomObject x2)
        {
            if (object.ReferenceEquals(x1, x2))
            {
                return true;
            }
            if (object.ReferenceEquals(x1, null) ||
                object.ReferenceEquals(x2, null))
            {
                return false;
            }
            return x1.Id == x2.Id;
        }
    }
