    public string XmlNodeFind(string xmlUrl, string keyword)
    {
        XmlDocument xdoc = new XmlDocument();
        xdoc.Load(xmlUrl);
        XmlNodeList nodes = xdoc.GetElementsByTagName(keyword);
        string result = "";
        XmlNode node = nodes[0];
        //result = node.LocalName + " - - " + node.Name + " - - " + node.NodeType + " - - " + node.OuterXml;
        //return result;    
        //foreach (XmlNode node in nodes){
        if (node != null)
        {
                result = OutputNode(node);
                return result;
        }
        else
          return "Node Does Not Exist !!! Try with a Valid Node.";
    } 
    public string OutputNode(XmlNode node)
    {
        try
        {
            if (node.HasChildNodes && node.FirstChild.Name != "#text")
            {
                XmlNodeList childern = node.ChildNodes;
                string str = "Child Nodes are:-";
                foreach (XmlNode child in childern)
                    str += "&lt;" + child.Name + "&gt;";
                return str;
            }
            else if ( node.OuterXml!=null && node.InnerText.ToString() != String.Empty) 
            {
                return node.InnerText.ToString();
            }
            /*else if (node.OuterXml != "" && node.Value != null)
            {
                string result;
                result = node.LocalName + " - - " + node.Name + " - - " + node.NodeType + " - - " + node.OuterXml;
                return result;
            }*/
            else if (node.ParentNode != null)
                return node.ParentNode.Name;
            else
                return node.Name;
            
            /*
            if (node.OuterXml != "")
            {
                if (node.HasChildNodes && node.FirstChild.Name != "#text")
                {
                    XmlNodeList childern = node.ChildNodes;
                    string str = "Child Nodes are:-";
                    foreach (XmlNode child in childern)
                        str += "&lt;" + child.Name + "&gt;";
                    return str;
                }
                else
                {
                    if (node.OuterXml == string.Empty)
                        return node.ParentNode.Name;
                    else
                        return node.OuterXml;
                    //return "Outer Xml null part";
                    //return node.OuterXml;
                }
            }
            else
            {
                //return "Outer Xml null part";
                //string result;
                // = node.LocalName + " - - " + node.Name + " - - " + node.NodeType + " - - " + node.OuterXml;
                //return result;
                if (node.ParentNode != null)
                {
                    string str = "Parent Node is :-";
                    str += node.ParentNode.Name.ToString();
                    return str;
                }
                else
                    return node.Name;
                //return node.OuterXml;
            }
        */
        }
        catch(Exception e)
        {
            return "Error Occured : Try Again with New Input Set";
        }
    }
