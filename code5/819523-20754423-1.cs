    public class Feature: IEquatable<Feature>
    {
        public bool Equals(Feature other)
        {
            return this.id.Equals(other.id);
        }
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }
    }
