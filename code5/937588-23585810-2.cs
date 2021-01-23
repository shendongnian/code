    XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("asd.xml");
            try
            {
                string sPath = "//Pages[@PageContentID=\"206\"]";
                var xmlNode = xmlDocument.SelectSingleNode(sPath);
                var chapter = xmlDocument.SelectSingleNode("//Chapter[@Name=\"Detailed Results\"]");
                XmlElement xNewChild = xmlDocument.CreateElement("Pages");
                xNewChild.SetAttribute("Name", "Another New Page");
                xNewChild.SetAttribute("PageContentID", Guid.NewGuid().ToString());
                xNewChild.SetAttribute("Template", "ReportTags");
                chapter.InsertAfter(xNewChild, xmlNode);
                xmlDocument.Save("asd.xml");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
