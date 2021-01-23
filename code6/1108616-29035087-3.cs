    public class UnitComparer : IEqualityComparer<Unit>
    {
        public bool Equals(Unit x, Unit y)
        {
            if (x == null || y == null) return false; // i don't know, is undefined equal to anything else?
            return x.UnitNum == y.UnitNum;
        }
        public int GetHashCode(Unit obj)
        {
            return obj == null || obj.UnitNum == null ? 0 : obj.UnitNum.GetHashCode();
        }
    }
