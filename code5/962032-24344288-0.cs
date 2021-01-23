    using (var db = new MyContext())
    using (var writer = XmlWriter.Create("MyContext.edmx"))
    {
        EdmxWriter.WriteEdmx(db, writer);
    }
