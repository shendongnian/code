    using (var serializationBuffer = new MemoryStream())
    {
        var foo = new Foo<Bar>() { Data = new Bar() { Data = "Some Data" } };
        RuntimeTypeModel.Default.Add(foo.Data.GetType(), false)
            .Add(foo.GetType().GetProperties().Select(p => p.Name).ToArray());
        Serializer.Serialize(serializationBuffer, foo);
        serializationBuffer.Seek(0, SeekOrigin.Begin);
        var deserialized = Serializer.Deserialize<Foo<Bar>>(serializationBuffer);
    }
