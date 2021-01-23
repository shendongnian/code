    using System.Data.Entity.Infrastructure; // namespace for the EdmxWriter class
    using (var ctx = new MyContext())
    {
        using (var writer = new XmlTextWriter(@"c:\Model.edmx", Encoding.Default))
        {
            EdmxWriter.WriteEdmx(ctx, writer);
        }
    }
