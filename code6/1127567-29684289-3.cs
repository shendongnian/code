     using (MemoryStream stream = new MemoryStream())
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(File.ReadAllText("XMLFile1.xml")); /// replace here with the xml string
                        writer.Flush();
                        stream.Position = 0;
                        csl = xs.Deserialize(stream) as CustomerList;
                    }
                }
