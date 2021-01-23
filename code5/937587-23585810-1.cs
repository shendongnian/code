    XDocument xmlDocument = XDocument.Load("asd.xml");
            try
            {
                var root = xmlDocument.Root;
                var pages = root.Elements("Chapter").Elements("Pages");
                var mypage = pages.Where(p => p.Attribute("PageContentID").Value == "206").FirstOrDefault();
                XElement xNewChild = new XElement("Pages", new XAttribute("Name", "Another New Page"), new XAttribute("PageContentID", Guid.NewGuid().ToString()), new XAttribute("Template", "ReportTags"));
                mypage.AddAfterSelf(xNewChild);
                xmlDocument.Save("asd.xml");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
