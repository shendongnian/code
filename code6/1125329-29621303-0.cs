    public class ParentSelfRef
    {
        [AutoIncrement]
        public int Id { get; set; }
        [References(typeof(ChildSelfRef))]
        public int? Child1Id { get; set; }
        [Reference]
        public ChildSelfRef Child1 { get; set; }
        [References(typeof(ChildSelfRef))]
        public int? Child2Id { get; set; }
        [Reference]
        public ChildSelfRef Child2 { get; set; }
    }
    public class ChildSelfRef
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
