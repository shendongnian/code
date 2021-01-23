    public class SchematicElevation : IEquatable<SchematicElevation>
    {
        public double Elevation { get; set; }
        public int ColumnId { get; set; }
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + Elevation.GetHashCode();
                hash = hash * 23 + ColumnId.GetHashCode();
                return hash;
            }
        }
        public override bool Equals(object other)
        {
            return Equals(other as SchematicElevation);
        }
        public bool Equals(SchematicElevation other)
        {
            return other != null && this.Elevation == other.Elevation &&
                   this.ColumnId == other.ColumnId;
        }
    }
