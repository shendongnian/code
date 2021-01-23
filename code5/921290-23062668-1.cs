    var item = new MyXml
    {
        Metadata = new List<Entry>
        {
            new Entry { Key = "key1", Value = "entry1" },
            new Entry { Key = "key2", Value = "entry2" },
            new Entry { Key = "key3", Value = "entry3" }
        }
    };
    
    var serializer = new XmlSerializer(typeof(MyXml));
    
    string xml;
    
    using(var stream = new StringWriter())
    using(var writer = XmlWriter.Create(stream,
                                        new XmlWriterSettings { Indent = true }))
    {
        serializer.Serialize(writer, item);
        xml = stream.ToString();
    }
    
    Console.WriteLine(xml);
