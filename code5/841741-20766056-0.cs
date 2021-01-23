    public void UpdateAccountDetails(XDocument doc, int id,XElement newContent)
     {
      var element = doc.Descendants("ProductDetail")
              .Where(p => (int)p.Element("ProductId").Value == id)
              .Select(p => p)
              .FirstOrDefault();
      if (element != null) {
          element.Element("AccountDetails").ReplaceWith(newContent);
          doc.Save(path);
           
     }
    }
