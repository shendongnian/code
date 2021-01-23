         using (XmlReader reader = XmlReader.Create(@"D:\Sample.xml"))
            {
                bool b = false;
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "parent")
                        {
                            b = true;
                        }
                        if (reader.Name == "kid")
                            b = false;
                        if (!b && reader.Name == "kid-prop")
                        {
                            Console.WriteLine(reader.ReadElementContentAsString());
                        }
                        if (b && reader.Name == "kid-prop")
                        {
                            Console.WriteLine(reader.ReadElementContentAsString());
                        }
                    }
                }
            }
