    private static void LoadAndWriteXML()
        {
            string headerFiles = "";
            string values = "";
            using (XmlReader reader = XmlReader.Create(@"C:\\bank.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && !reader.Name.Equals("Bank"))   // we have to skip root node means bank node.
                    {
                        headerFiles += reader.Name + " ";
                        values += reader.ReadString() + " ";
                    }
                }
            }
            StreamWriter writer = new StreamWriter(@"C:\\Test.txt");
            writer.WriteLine(headerFiles.Trim());
            writer.WriteLine(values.Trim());
            writer.Close();
            
        }
