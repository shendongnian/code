    public class Product
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
    public class ReadAndWrite
    {
        var productList = new List<Product>();
        using(XmlReader reader = XmlReader.Create("path/to/file.xml"))
        {
            Product p;
            while(reader.Read())
            {
                if(reader.IsStartElement())
                {
                    switch(reader.Name)
                    {
                        case "product": 
                            p = new Product(); 
                            break;
 
                        case "code" :
                            reader.Read(); //Point it one step forward to read the value
                            p.Code = reader.Value;
                            break;
                        //Etc...                           
                    }
                }
                
                if(reader.Name == "product" && reader.NodeType == XmlNodeType.EndElement)
                {
                    productList.Add(p);
                }
            }
        }
        var duplicates = productList.GroupBy(p => p.Code).Where(x => x.Count() > 1).SelectMany(v => v).ToList();
        
        using(XmlWriter writer = XmlWriter.Create("path/to/duplicates.xml"))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("Duplicates");
            foreach(var duplicate in duplicates)
            {
                writer.WriteStartElement("Product");
		        writer.WriteElementString("Name", duplicate.Name);
                //Etc...
		        writer.WriteEndElement()
            }
            writer.WriteEndElement();
	        writer.WriteEndDocument();
        }
    }
