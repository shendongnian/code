    var serializer = JsonSerializer.CreateDefault();
    string s;
    using (var stringWriter = new StringWriter())
    {
       serializer.Serialize(stringWriter, someObjectContainingEnumProperty);
       s = stringWriter.ToString();
    }
