    var serializer = new JsonSerializer();
    var sb = new StringBuilder();
    var foo = new Foo
    {
        Bar = 9999999999999999999999999999M
    };
    
    using (var textWriter = new StringWriter(sb))
    using (var jsonWriter = new JsonTextWriter(textWriter))
    {
        serializer.Serialize(jsonWriter, foo);
    }
    Debug.WriteLine(sb);
