    XmlReader ReadXML = XmlReader.Create("XML FILE"); //Creates XMLReader instance
       while (ReadXML.NodeType != XmlNodeType.EndElement) //Sets the node types to closes. 
        {
           ReadXML.Read(); //Reads the XML Doc
                if (ReadXML.Name == "Child") //Focuses node 
                {
                   while (ReadXML.NodeType != XmlNodeType.EndElement)//If the node is not empty
                     {
                        ReadXML.Read();
                        if (ReadXML.NodeType == XmlNodeType.Text) //Gets the text in the node
                        {
                            Console.WriteLine("In 'Child' node = {0}", ReadXML.Value);
                            Console.ReadKey();
                        }
                    }
              }
          }
