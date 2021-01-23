    public virtual XmlNodeType MoveToContent()
    {
      do
      {
        switch (this.NodeType)
        {
          case XmlNodeType.Element:
          case XmlNodeType.Text:
          case XmlNodeType.CDATA:
          case XmlNodeType.EntityReference:
          case XmlNodeType.EndElement:
          case XmlNodeType.EndEntity:
            return this.NodeType;
          case XmlNodeType.Attribute:
            this.MoveToElement();
            goto case XmlNodeType.Element;
          default:
            continue;
        }
      }
      while (this.Read());
      return this.NodeType;
    }
