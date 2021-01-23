    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class TestAttribute : Attribute
    {
        public TestAttribute(Type target)
        {
            if (target == typeof(object))
            {
                
            }
            else if (target == typeof(PropertyInfo))
            {
                
            }
        }
    }
    [TestAttribute(typeof(object))]
    class SomeClass
    {
        [TestAttribute(typeof(PropertyInfo))]
        public string SomeProperty { get; set; }
    }
