    public static void Foo (string string1, string string2) {
       MyExample example = new MyExample();
       var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.GetProperties().FirstOrDefault(x => x.Name == string1));
       var prop = type.GetProperty(string1, BindingFlags.Public | BindingFlags.Instance);
       if(prop != null && prop.CanWrite) {
            prop.SetValue(example, string1, null);
       }
    }
