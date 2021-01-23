    public class VersionSettingComparer : IEqualityComparer<VersionSettings>
    {
        public bool Equals(VersionSettings x, VersionSettings y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            return x.Culture == y.Culture;
        }
        public int GetHashCode(VersionSettings obj)
        {
            if(obj == null) return 0;
            return obj.Culture == null ? 0 : obj.Culture.GetHashCode();
        }
    }
