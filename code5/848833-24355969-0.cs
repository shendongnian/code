        static private string FindPageById(string startingID, string pageId)
        {
            string strXML;
            XmlDocument xmlDoc = new XmlDocument();
            onApp.GetHierarchy(startingID, HierarchyScope.hsPages, out strXML);
            xmlDoc.LoadXml(strXML);
            foreach (XmlElement element in xmlDoc.SelectNodes("//one:Page", nsmgr))
            {
                string thisPageId = element.GetAttribute("ID");
                string name = element.GetAttribute("name");
                System.Diagnostics.Debug.WriteLine(name);
                string hyperlink;
                onApp.GetHyperlinkToObject(thisPageId, "", out hyperlink);
                HRef href = GetHref(hyperlink);
                if (href.PageId == pageId)
                    return thisPageId;
            }
            return "";
        }
