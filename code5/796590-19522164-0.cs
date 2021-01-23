    public class MyClass:IEquatable<MyClass>
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public override bool Equals(object obj)
        {
            return Equals(obj as MyClass);
        }
        public bool Equals(MyClass other)
        {
            if (other == null)
                return false;
            return Type == other.Type &&
                Id == other.Id;
        }
        public override int GetHashCode()
        {
            return Type.GetHashCode() * 79 + Id;
        }
    }
