    public class TestClass
    {
        public IReadOnlyCollection<int> Values { get; set; }
    }
    public static class TestClassExtensions
    {
        public static IEnumerable<int> AsEnumerable(this TestClass cls)
        {
            return cls.Values.AsEnumerable();
        }
    }
    
    // Call
    var cls = new TestClass();
    var enum = cls.AsEnumerable();
