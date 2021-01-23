    public sealed class Ignore : Attribute { }
    public sealed class test<T> : IEnumerable<T> where T : new()
    {
        [Ignore]
        public test_2 SomeProperty { get; set; }
    }
    public class test_2
    {
        public string TestData { get; set; }
    }
