      var inDoc = XDocument.Parse(i);
      var metaDoc = XDocument.Parse(m);
      var body = inDoc.Root.Element("Body");
 
      body.ReplaceNodes(metaDoc.Root);
      
      // helper to show the result     
      var sb = new StringBuilder();
      using(var xw = XmlWriter.Create(sb)) 
      {
         inDoc.WriteTo(xw);
      }
      sb.Dump(); // LinqPad helper
