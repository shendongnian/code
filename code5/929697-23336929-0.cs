    public class Catalog : IEquatable<Catalog>
    {
        public string Name { get; set; }
        public bool Equals(Catalog other)
        {
            return Name == other.Name;
        }
    }
