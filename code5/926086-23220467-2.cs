    [TypeConverter(typeof(IntConverter))]
    [EditorAttribute(typeof(MyEditor), typeof(UITypeEditor))]
    public int SomeProperty
    {
        ...
    }
