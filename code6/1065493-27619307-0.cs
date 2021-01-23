     XmlDocument doc = new XmlDocument();
     byte[] content = File.ReadAllBytes(path);
     using (var memStream = new MemoryStream(content))
     {
         doc.Load(memStream);
     }
     XmlNode NName = doc.CreateElement("default");
     XmlNode SNO = doc.CreateElement("SNo");
     SNO.InnerText = "2";
     NName.AppendChild(SNO);
     doc.DocumentElement.AppendChild(NName);
     doc.Save(path);
