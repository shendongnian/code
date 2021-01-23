    public sealed class DatedSet : IEquatable<DatedSet>
    {
        readonly DateTime _added;
        readonly int _id;
        public DateTime Added
        {
            get { return _added; }
        }
        public int ID
        {
            get { return _id; }
        }
        public DatedSet(int id)
            : this(id, DateTime.Now)
        {
        }
        public DatedSet(int id, DateTime added)
        {
            id.ThrowDefault("id");
            added.ThrowDefault("added");
            _id = id;
            _added = added;
        }
        public bool Equals(DatedSet other)
        {
            if (other == null) return false;
            return this.ID == other.ID;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            var ds = obj as DatedSet;
            return ds == null ? false : Equals(ds);
        }
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
