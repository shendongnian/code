    XmlDocument doc = new XmlDocument();
            doc.Load(newPath);
            XmlNode node = doc.DocumentElement.GetElementsByTagName("DST2").Item(0);
            StringBuilder sb = new StringBuilder();
            sb.Append(node.InnerText);
            DST2 = sb.ToString();
            File.WriteAllText(@"c:\textFile.txt", sb.ToString(), Encoding.Unicode);
