    public class myListclass : IEquatable<myListclass>
    {
        public Nullable<decimal> ClassId { get; set; }
        public Nullable<decimal> SectionId { get; set; }
        public Nullable<decimal> MediumId { get; set; }
        public Nullable<decimal> StreamId { get; set; }
        public Nullable<decimal> ShiftId { get; set; }
        public bool Equals(myListclass other)
        {
            return
                other != null &&
                this.ClassId == other.ClassId &&
                this.SectionId == other.SectionId &&
                this.MediumId == other.MediumId &&
                this.StreamId == other.StreamId &&
                this.ShiftId == other.ShiftId;
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as myListclass);
        }
        public override int GetHashCode()
        {
            // http://stackoverflow.com/a/263416/1149773
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + ClassId.GetHashCode();
                hash = hash * 23 + SectionId.GetHashCode();
                hash = hash * 23 + MediumId.GetHashCode();
                hash = hash * 23 + StreamId.GetHashCode();
                hash = hash * 23 + ShiftId.GetHashCode();
                return hash;
            }
        }
    }  
