    private static void Invert(XmlNode startingNode, string path)
    {
        XmlNode node = startingNode.SelectSingleNode(path);
        if (node != null)
        {
            XmlNode firstChild = node.SelectSingleNode("*");
            
            if(firstChild != null)
            {
                XmlNodeList others = 
                     node.SelectNodes("node()[not(self::*)] | *[position() > 1]");
                foreach (XmlNode other in others)
                {
                    firstChild.AppendChild(other);
                }
                node.ParentNode.ReplaceChild(firstChild, node);
            }
        }
    }
