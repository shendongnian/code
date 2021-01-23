    sealed class NameEqualityComparer : IEqualityComparer<KKey>
    {
        public bool Equals(KKey x, KKey y)
        {
            return string.Equals(x.Name, y.Name);
        }
        public int GetHashCode(KKey obj)
        {
            return (obj.Name != null ? obj.Name.GetHashCode() : 0);
        }
    }
    Dictionary<KKey, string> myDictionary = new Dictionary<KKey, string>(new NameEqualityComparer());
