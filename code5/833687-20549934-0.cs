    void DeleteNode(string fileName)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(Server.MapPath("~/uploads/banners.xml"));
        
        //Get all the bannerMain nodes.
        XmlNodeList nodelist = doc.SelectNodes("/xml//bannerMain");
    
        if (nodelist != null)
        {
            foreach (XmlNode node in nodelist)
            {
                //Look for then filename child. If it contains desired value
                //delete the entire bannerMain node.
                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.InnerText == fileName)
                    {
                        node.ParentNode.RemoveChild(node);
                    }
                }
            }
    
            doc.Save(Server.MapPath("~/uploads/banners.xml"));
        }
    }
