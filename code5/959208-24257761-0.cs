    public class Organisation
    {
        public string Name { get; set; }
        public string Country { get; set; }
     
        public override int GetHashCode()
        {
            unchecked
            {
                int multiplier = 31;
                int hash = GetType().GetHashCode();
     
                hash = hash * multiplier + (Name == null ? 0 : Name.GetHashCode());
                hash = hash * multiplier + (Country == null ? 0 : Country.GetHashCode());
     
                return hash;
            }
        }
    }
