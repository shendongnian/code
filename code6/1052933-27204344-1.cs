      var id2 = new XmlDocument();
      id2.Load(new StringReader(i));
      
      var md2 = new XmlDocument();
      md2.Load(new StringReader(m));
      
      var b2 = id2.SelectSingleNode("//Body");
      b2.InnerXml = md2.DocumentElement.OuterXml;
      
      sb = new StringBuilder();
      using(var xw = XmlWriter.Create(sb)) {
         id2.Save(xw);
      }
      sb.Dump("2");
