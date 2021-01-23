    // tested with Dictionary<T>
    public class Animal : IEquatable<Animal>
    {
        public override int GetHashCode()
        {
            return (species + breed).GetHashCode();
        }
        public bool Equals(Animal other)
        {
            return other != null &&
                   (
                      this.species == other.species &&
                      this.breed == other.breed &&
                      this.color == other.color                   
                   );
        }
    }
