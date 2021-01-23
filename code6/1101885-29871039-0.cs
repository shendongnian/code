     string url = "/templates" + Request.Url.LocalPath + ".html";
                XmlDocument doc = new XmlDocument();
                try
                {
                    doc.Load(Server.MapPath(url));
                }
                catch
                {
                    return HttpNotFound(); 
                }
                var settings = new System.Xml.XmlWriterSettings();
                var propInfo = settings.GetType().GetProperty("OutputMethod");
                propInfo.SetValue(settings, System.Xml.XmlOutputMethod.Html, null);
                var stream = new System.IO.StringWriter();
                var writer = System.Xml.XmlWriter.Create(stream, settings);
              //  XmlElement elem = doc.CreateElement("book", "aaaa", "http://www.com");
              ////  doc.DocumentElement.AppendChild(elem);
              //  doc.DocumentElement.(elem, doc.DocumentElement.LastChild);
                XmlDocument doc2 = new XmlDocument();
                XmlElement element1 = doc2.CreateElement(string.Empty, "html", string.Empty);
                doc2.AppendChild(element1);
                XmlElement element2 = doc2.CreateElement(string.Empty, "head", string.Empty);
                XmlElement element4 = doc2.CreateElement(string.Empty, "title", string.Empty);
                XmlText text1 = doc2.CreateTextNode("TheHaileSelassie.Com :: "+doc.GetElementsByTagName("h1")[0].InnerText);
                element4.AppendChild(text1);
                element2.AppendChild(element4);
                doc2.DocumentElement.AppendChild(element2);
                XmlElement element3 = doc2.CreateElement(string.Empty, "body", string.Empty);
                XmlDocumentFragment xfrag = doc2.CreateDocumentFragment();
                xfrag.InnerXml = doc.InnerXml;
                element3.AppendChild(xfrag);
                doc2.DocumentElement.AppendChild(element3);
                //doc2.DocumentElement.AppendChild(xfrag);
                doc2.Save(writer);
                return Content(System.Net.WebUtility.HtmlDecode(stream.ToString()));
