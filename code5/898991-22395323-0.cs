      var doc = new XmlDocument();
        doc.LoadXml("<x>“∞π”</x>");
        using (var buf = new MemoryStream())
        {
            using (var writer =  XmlWriter.Create(buf, 
                  new XmlWriterSettings{Encoding= Encoding.ASCII}))
            {
                doc.Save(writer);
            }
            Console.Write(Encoding.ASCII.GetString(buf.ToArray()));
        }
