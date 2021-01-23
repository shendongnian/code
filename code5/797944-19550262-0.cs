    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    class TestAttribute : Attribute
    {
        public TestAttribute(params string[] values)
        {
        }
    }
    [Test("123", "456")]
    class A
    {
    }
