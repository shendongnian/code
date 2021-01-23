    using (var ms = new MemoryStream())
    {
        var bf = new BinaryFormatter();
        bf.Serialize(ms, new Device {
            AssociatedMibEntity = new MibEntity { Name = "Foo"}});
        ms.Position = 0;
        var clone = (Device)bf.Deserialize(ms);
        Console.WriteLine(clone.AssociatedMibEntity.Name); // Foo
    }
