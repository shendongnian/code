    public class MyClass
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public override int GetHashCode()
        {
            return this.Id;
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
