    public class Blog : IEquatable<Blog>
    {
        // other stuff
        public bool Equals(Blog other)
        {
            return this.Id.Equals(other.Id);
        }
    }
