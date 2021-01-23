                XML = new XmlDocument();
                using (XmlTextReader reader = new XmlTextReader("C:\\Path\\File.xml"))
                {
                    reader.Namespaces = false;
                    XML.Load(reader);
                }
                XmlNodeList items = XML.DocumentElement.SelectNodes("//Item");
                foreach (XmlNode item in items)
                {
                    PrintKeyValue("ISBN10", item["ASIN"].InnerText);
                    XmlNode attrib = item.SelectSingleNode(".//ItemAttributes");
                    PrintKeyValue("Title", attrib["Title"].InnerText);
                    XmlNodeList authors = attrib.SelectNodes(".//Author");
                    StringBuilder sb = new StringBuilder();
                    int count = 0;
                    foreach (XmlNode author in authors)
                    {
                        count++;
                        if (count > 1) { sb.Append(", "); }
                        sb.Append(author.InnerText);
                    }
                    PrintKeyValue("Authors", sb.ToString());
                }
