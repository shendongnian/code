    public class Items : IEquatable<Items>
    {
        public string Title { get; set; }
        public List<int> Parts { get; set; }
    
        public bool Equals(Author other)
        {
            if (Title == other.Title && Parts.SequenceEqual(other.Parts))
                return true;
    
            return false;
        }
    
        public override int GetHashCode()
        {
            return  Title == null ? 0 : Title.GetHashCode();
        }
    }
