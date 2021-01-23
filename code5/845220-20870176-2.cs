    using System;
    using System.Xml;
    
    class Program
    {
        static void Main()
        {
            using (var reader = XmlReader.Create("5.xml"))
            {
                string title = null, publisher = null, description = null, published = null;
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "book")
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}", title, publisher, description, published);
                    }
    
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "title")
                    {
                        title = reader.ReadInnerXml();
                    }
    
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "publisher")
                    {
                        publisher = reader.ReadInnerXml();
                    }
    
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "description")
                    {
                        description = reader.ReadInnerXml();
                    }
    
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "published")
                    {
                        published = reader.ReadInnerXml();
                    }
                }
            }
        }
    }
