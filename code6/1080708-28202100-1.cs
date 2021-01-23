    static public string getXPath(XmlNode _xmlNode)
    {
        Stack<string> xpath = new Stack<string>();
        while (_xmlNode != null)
        {
            if (_xmlNode as XmlElement != null)
                xpath.Push(_xmlNode.Name);
            _xmlNode = _xmlNode.ParentNode as XmlElement;
        }
        return string.Join("/", xpath.ToArray());
    }
