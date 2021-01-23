    public class AClass
    {
        public class AnotherClass
        {
            public int AProperty { get; set; }
        }
    }
    class TestVM
    {
        public List<AClass.AnotherClass> NestedTypeList { get; set; }
    }
