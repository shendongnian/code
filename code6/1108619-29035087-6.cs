    public class UnitComparer : IEqualityComparer<Unit>
    {
        public bool Equals(Unit x, Unit y)
        {
            if (x == null && y == null) return true; 
            if (x == null || y == null) return false; 
            return x.UnitNum == y.UnitNum;
        }
        public int GetHashCode(Unit obj)
        {
            return obj == null || obj.UnitNum == null ? 0 : obj.UnitNum.GetHashCode();
        }
    }
