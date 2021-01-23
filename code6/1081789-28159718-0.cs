    private string extractSectionContents(XElement section)
    {
        string output = "";
        foreach(var node in section.Nodes())
        {
            if(node.NodeType == System.Xml.XmlNodeType.Text)
            {
                output += string.Format("{0}", node);
            }
            else if(node.NodeType == System.Xml.XmlNodeType.Element)
            {
                output += string.Format(" {0} ", ((XElement)node).Value);
            }
        }
    
        return output;
    }
