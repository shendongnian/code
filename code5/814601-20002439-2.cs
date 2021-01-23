    public class Foo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            Foo other = obj as Foo;
            if (other == null) return false;
            if (Object.ReferenceEquals(this, obj)) return true;
            return this.ID == other.ID;
        }
        public override int GetHashCode()
        {
            return ID;
        }
    }
