    var ser = new XmlSerializer(typeof(YourRootType));
    YourRootType root = (YourRootType)ser.Deserialize(source);
    Console.WriteLine(root.Foo);
    foreach(Bar bar in root.Bars) {
        Console.WriteLine(bar.Name);
        Console.WriteLine(bar.Id);
    }
