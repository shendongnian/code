    public sealed class myObjectEqualityComparer : IEqualityComparer<myObject>
    {
        public bool Equals(myObject x, myObject y)
        {
            // null checking here
            return x.Id == y.Id;
        }
        public int GetHashCode(myObject obj)
        {
            return obj.Id.GetHashCode();
        }
    }
