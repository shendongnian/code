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
               //here just to show that you can iterate as xmlDoc 
              }
    
     
