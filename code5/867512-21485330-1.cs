    MemoryStream ms = new MemoryStream();
            XmlWriterSettings xws = new XmlWriterSettings();
            xws.OmitXmlDeclaration = true;
            xws.Indent = true;
            XDocument xDoc = XDocument.Parse(utf8Xml);
            xDoc.Declaration.Encoding = "utf-16";
            using (XmlWriter xw = XmlWriter.Create(ms, xws))
            {
                xDoc.WriteTo(xw);
            }
            Encoding ut8 = Encoding.UTF8;
            Encoding ut116 = Encoding.Unicode;
            byte[] utf16XmlArray = Encoding.Convert(ut8, ut116, ms.ToArray());
            var utf16Xml = Encoding.Unicode.GetString(utf16XmlArray);
