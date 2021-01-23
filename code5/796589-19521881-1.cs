    public class MyClass
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash + 23 * this.Type.GetHashCode();
            hash = hash + 23 * this.Id.GetHashCode();
            return hash;
        }
    }
    public class MyClassList : List<MyClass>
    {
        public MyClassList(IEnumerable<MyClass> enumerable) : base(enumerable) { }
        public override int GetHashCode()
        {
            return this.Aggregate(17, (state, current) => state * 23 + current.GetHashCode());
        }
    }
