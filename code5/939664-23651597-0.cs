    var serializer = JsonSerializer.CreateDefault();
    string s;
    using (var stringWriter = new StringWriter())
    {
       serializer.Serialize(new StringWriter(), someObjectContainingEnumProperty);
       s = stringWriter.ToString();
    }
