    node.MoveNext();
    
    using (StringWriter sw = new StringWriter())
    {
      using (XmlWriter xw = XmlWriter.Create(sw))
      {
        node.Current.WriteSubtree(xw);
      }
      return sw.ToString();
    }
