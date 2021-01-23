    public class DefaultValueTestClass
    {
        public DefaultValueTestClass()
        {
            Foo = 10000;
        }
        [DefaultValue(10000)]
        public int Foo { get; set; }
    }
