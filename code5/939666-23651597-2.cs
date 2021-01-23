    var serializer = JsonSerializer.Create();
    string s;
    using (var stringWriter = new StringWriter())
    {
       serializer.Serialize(stringWriter, someObjectContainingEnumProperty);
       s = stringWriter.ToString();
    }
