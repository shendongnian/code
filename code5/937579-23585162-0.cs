    public class Record
    {
        public int Id { get; set; }
        public bool IsEnabled { get; set; }
        protected bool Equals(Record other)
        {
            return Id == other.Id;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Record) obj);
        }
        public override int GetHashCode()
        {
            return Id;
        }
    }
