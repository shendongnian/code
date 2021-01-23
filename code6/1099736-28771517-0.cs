    public class Schema
    {
        public int High { get; set; }
        public int Low { get; set; }
        public int OpenValue { get; set; }
        public double Price { get; set; }
        public DateTime Time { get; set; }
        public int Volume { get; set; }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Schema)obj);
        }
        protected bool Equals(Schema other)
        {
            //You may would like to compare only Date here.
            return High == other.High && Low == other.Low && OpenValue == other.OpenValue && Price.Equals(other.Price) && Time.Equals(other.Time) && Volume == other.Volume;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = High;
                hashCode = (hashCode * 397) ^ Low;
                hashCode = (hashCode * 397) ^ OpenValue;
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                hashCode = (hashCode * 397) ^ Time.GetHashCode();
                hashCode = (hashCode * 397) ^ Volume;
                return hashCode;
            }
        }
    }
