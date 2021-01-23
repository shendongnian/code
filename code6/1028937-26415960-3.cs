    public class IgaAdKey : IEquatable<IgaAdKey>, IComparable<IgaAdKey>
    {
        public int ResourceId;
        public int EditionId;
        public int LocationId;
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            else if (ReferenceEquals(null, obj))
                return false;
            if (obj.GetType() != GetType())
                return false;
            var other = (IgaAdKey)obj;
            return ResourceId == other.ResourceId && EditionId == other.EditionId && LocationId == other.LocationId;
        }
        public override int GetHashCode()
        {
            return ResourceId.GetHashCode() ^ EditionId.GetHashCode() ^ LocationId.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("ResourceId={0}, EditionId={1}, LocationId={2}", ResourceId, EditionId, LocationId);
        }
        #region IEquatable<IgaAdKey> Members
        public bool Equals(IgaAdKey other)
        {
            return Equals((object)other);
        }
        #endregion
        #region IComparable<IgaAdKey> Members
        public int CompareTo(IgaAdKey other)
        {
            if (other == null)
                return -1; // At end?
            if (object.ReferenceEquals(this, other))
                return 0;
            int diff;
            if ((diff = ResourceId.CompareTo(other.ResourceId)) != 0)
                return diff;
            if ((diff = EditionId.CompareTo(other.EditionId)) != 0)
                return diff;
            if ((diff = LocationId.CompareTo(other.LocationId)) != 0)
                return diff;
            return 0;
        }
        #endregion
    }
