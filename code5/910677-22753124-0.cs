    public class CustomComparer : IEqualityComparer<CustomObject>
    {
        public bool Equals(CustomObject x, CustomObject y)
        {
            return x.Name.Equals(y);
        }
        public int GetHashCode(CustomObject obj)
        {
            return obj.Name.GetHashCode();
        }
    }
