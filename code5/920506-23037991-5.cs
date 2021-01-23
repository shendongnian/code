    public class NameComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == null && y == null) return 0;
            if (x == null || y == null) return -1; 
            var parts1 = x.Split();
            var parts2 = y.Split();
            if (parts1.Length > 1 && parts2.Length > 1)
            {
                if (parts1[0] != parts2[0]) return parts1[0].CompareTo(parts2[0]);
                return parts1[1].CompareTo(parts2[1]);
            }
            return x.CompareTo(y);
        }
    }
