    public class TestEquality : IEqualityComparer<Friend>
    {
        public bool Equals(Friend x, Friend y)
        {
            return x.Id == y.Id && x.Name == y.Name; // or however you determine equality
        }
        public int GetHashCode(Friend obj)
        {
            return obj.GetHashCode();
        }
    }
