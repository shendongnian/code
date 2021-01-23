    /// <summary>
    /// Fully equatable MyObject
    /// </summary>
    public class MyObject : IEquatable<MyObject>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            // obj is object, so we can use its == operator
            if (obj == null)
            {
                return false;
            }
            MyObject other = obj as MyObject;
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            return this.InnerEquals(other);
        }
        public bool Equals(MyObject other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            return this.InnerEquals(other);
        }
        private bool InnerEquals(MyObject other)
        {
            // Here we know that other != null;
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return this.Id == other.Id && this.Name == other.Name;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                // From http://stackoverflow.com/a/263416/613130
                int hash = 17;
                hash = hash * 23 + this.Id.GetHashCode();
                hash = hash * 23 + (this.Name != null ? this.Name.GetHashCode() : 0);
                return hash;
            }
        }
    }
