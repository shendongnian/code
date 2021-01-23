    public class Items : IEquatable<Items>
    {
        public int Total { get; set; }
        public List<int> Parts { get; set; }
    
        public bool Equals(Author other)
        {
            if (Total == other.Total && Parts.SequenceEqual(other.Parts))
                return true;
    
            return false;
        }
    
        public override int GetHashCode()
        {
            return Total.GetHashCode() * Parts.GetHashCode();
        }
    }
