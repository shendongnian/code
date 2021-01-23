    public sealed class PrimaryKeyModel : IEquatable<PrimaryKeyModel>
    {
        // TODO: Make these read-only (mutable keys are a bad idea...)
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
        public int RowNumber { get; set; }
        public override bool Equals(object other)
        {
            return Equals(other as PrimaryKeyModel);
        }
        public bool Equals(PrimaryKeyModel other)
        {
            return other != null &&
                   ColumnName == other.ColumnName &&
                   ColumnValue == other.ColumnValue &&
                   RowNumber == other.RowNumber;
        }
        public override int GetHashCode()
        {
            int hash = 23;
            hash = hash * 31 + ColumnName == null ? 0 : ColumnName.GetHashCode();
            hash = hash * 31 + ColumnValue == null ? 0 : ColumnValue.GetHashCode();
            hash = hash * 31 + RowNumber;
            return hash;
        }
    }
