    class TNSyndicationItem : SyndicationItem
    protected override void WriteElementExtensions(XmlWriter writer, string version)
    {
      writer.WriteElementString("ext:abstract", this.Abstract);
      writer.WriteElementString("ext:channel", this.Channel);
    }
    
