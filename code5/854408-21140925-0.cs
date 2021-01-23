            foreach (XmlNode node in elementList)
            {                
                Console.Write(node.Name + " ");
                foreach (XmlAttribute attr in node.Attributes)
                {
                    Console.Write(attr.Name + ":" + attr.Value + " ");
                }
                Console.WriteLine();
            }
