            using (var stringWriter = new StringWriter())
            using (StreamWriter writer = new StreamWriter(@"C:\<Path to File>\testing.xml"))
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {
                doc.WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();
                writer.Write(stringWriter.GetStringBuilder().ToString());
                Console.WriteLine(stringWriter.GetStringBuilder().ToString());
            }
