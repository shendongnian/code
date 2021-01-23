    var listOfViewFields = new List<string>();
    foreach (XmlNode node in listItems)
    {
       if (node.Name == "rs:data")
       {
          for (int f = 0; f < node.ChildNodes.Count; f++)
          {
          if (node.ChildNodes[f].Name == "z:row")
          {
            var xmlAttributeCollection = node.ChildNodes[f].Attributes;
            if (xmlAttributeCollection != null)
            {
                listOfViewFields.Add(xmlAttributeCollection["ows_FIELD YOU WISH TO RETRIEVE"].Value);
            }
         }
      }
    }
