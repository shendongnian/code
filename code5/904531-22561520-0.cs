    foreach (var subContainer in subContainers)
    {
       foreach (var attrContainer in subContainer.Elements("AttrContainer"))
       {
          var attr = attrContainer.Elements("Attr").FirstOrDefault();
          if (attr != null)
          {
             var oldValue = attr.Attribute("type").Value;
             attr.Attribute("type").Value = "something completely different";
          }
       }
    }
