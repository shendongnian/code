    public struct DummyStruct : IEquatable<DummyStruct>
    {
        public string Name { get; set; }
        public bool Equals(DummyStruct other) //<- he is the man
        {
            return Name == other.Name;
        }
        public override bool Equals(object obj)
        {
            throw new InvalidOperationException("Shouldn't be called, since we use Generic Equality Comparer");
        }
        public override int GetHashCode()
        {
            return Name == null ? 0 : Name.GetHashCode();
        }
    }
    public class DummyClass : IEquatable<DummyClass>
    {
        public string Name { get; set; }
        public bool Equals(DummyClass other)
        {
            return Name == other.Name;
        }
        public override bool Equals(object obj) 
        {
            throw new InvalidOperationException("Shouldn't be called, since we use Generic Equality Comparer");
        }
        public override int GetHashCode()
        {
            return Name == null ? 0 : Name.GetHashCode();
        }
    }
