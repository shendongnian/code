    public static void Foo (string string1, string string2) {
        MyExample example = new MyExample();
        var prop = example.GetType().GetProperty(string1, BindingFlags.Public | BindingFlags.Instance);
        if(prop != null && prop.CanWrite) {
             prop.SetValue(example, string1, null);
        }
    }
