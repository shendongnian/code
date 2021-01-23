    public class DefaultValueTestClass
    {
        [DefaultValue(10000)]
        public int Foo { get; set; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeFoo() { return true; }
    }
