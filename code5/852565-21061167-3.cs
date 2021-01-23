    using(XmlWriter writer = XmlWriter.Create(fileName))
    {
       writer.WriteStartDocument();
       writer.WriteStartElement("Products");
    
       foreach (var pv in pvs)
       {
           writer.WriteStartElement("Product");
           writer.WriteAttributeString("SKU", pv.Sku);
           writer.WriteElementString("Name", pv.Product.Name);           
           // ...
           writer.WriteEndElement();
       }
    
       writer.WriteEndElement();
       writer.WriteEndDocument();
    }
