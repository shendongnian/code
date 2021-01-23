    public class Column
    {
        public string SectionName;
        public string StirrupType;
        public int StirrupSize;
        public double StirrupSpacing;
        public override bool Equals(object obj)
        {
            Column col2 = obj as Column;
            if(col2 == null) return false;
            return SectionName    == col2.SectionName
                && StirrupType    == col2.StirrupType 
                && StirrupSize    == col2.StirrupSize
                && StirrupSpacing == col2.StirrupSpacing;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (SectionName ?? "").GetHashCode();
                hash = hash * 23 + (StirrupType ?? "").GetHashCode();
                hash = hash * 23 + StirrupSize.GetHashCode();
                hash = hash * 23 + StirrupSpacing.GetHashCode();
                return hash;
            }
        }
    }
