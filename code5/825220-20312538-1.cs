      HtmlWeb htmlWeb = new HtmlWeb();
      MemoryStream ms = new MemoryStream();
            XmlTextWriter xmlTxtWriter = new XmlTextWriter(ms, Encoding.ASCII);            
           htmlWeb.LoadHtmlAsXml(uriofhtmlPageToload, xmlTxtWriter);
            ms.Position = 0;
            XDocument xdoc = XDocument.Load(ms);
            XElement xHtml = xdoc.Root;
            string nameSpace = "{" + xdoc.Root.GetDefaultNamespace().ToString() + "}";
            XElement xBody = xHtml.Element(nameSpace + "body");
            List<XElement> xBodyElts = xBody.Descendants().ToList();
            string elt = string.Empty;
            foreach (var eltPage in xBodyElts)
            {
                if (eltPage.Name == nameSpace + "div")
                {
                    if (eltPage.Attribute("class") != null && eltPage.Attribute("class").Value == "page")
                    {
                        foreach (XElement eltBlockh4 in eltPage.Descendants(nameSpace + "h4"))
                        {
                            foreach (XElement eltBlockspan in eltBlockh4.Descendants(nameSpace + "span"))
                            {
                                if (eltBlockspan.Attribute("class") != null && eltBlockspan.Attribute("class").Value == "trim")
                                {
                                    elt = eltBlockspan.Value;
                                }
                            }
                        }
                    }
                }
            }
