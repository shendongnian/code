    var settings = new XmlWriterSettings
    {
        Indent = false,
        NewLineChars = String.Empty
    };
    using (var wr = XmlWriter.Create(fileName, settings))
    {
        wr.Formatting = Formatting.None;
        doc.Save(wr);
    }
