    public class KKey : IEquatable<KKey>
    {
        public string Name { get; set; }
        public Guid Guid { get; set; }
        public bool Equals(KKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name);
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as KKey);
        }
        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
    Dictionary<KKey, string> myDictionary = new Dictionary<KKey, string>();
