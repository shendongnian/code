    private readonly Queue<String> externalSources = new Queue<String>();
    
    protected override void DeserializeElement(XmlReader reader, bool serializeCollectionKey)
    {
        var externalFile = reader.GetAttribute("File");
        if(!String.IsNullOrWhiteSpace(externalFile))
        {
            externalSources.Enqueue(externalFile);
        }
    
        base.DeserializeElement(reader, serializeCollectionKey);
    }
    protected override void PostDeserialize()
    {
        base.PostDeserialize();
    
        // Override data with local stuff
        if (externalSources.Count == 0) return;
    
        string file = externalSources.Dequeue();
        if (System.IO.File.Exists(file))
        {
            var reader = XmlReader.Create(file);
            base.DeserializeSection(reader);
        }
    }
