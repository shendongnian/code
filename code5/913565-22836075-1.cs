    XmlWriter writer;
            int count=0;
            foreach (XmlSchema s in schemaSet.Schemas())
            {
                writer = XmlWriter.Create((count++).ToString()+"_contosobooks.xsd");
                s.Write(writer);
                writer.Close();
                Console.WriteLine("Done " + count);
            }
            reader.Close();
