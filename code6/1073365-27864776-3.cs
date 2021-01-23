    public string GetId(string UserName)
    {
        XDocument xDoc = XDocument.Load("Users.xml");
        XmlNodeList _users = xDoc.SelectNodes("//users/user");
        string _id = null;
        foreach (XmlNode _node in _users)
        {
            if (_node.SelectSingleNode("username").InnerText == UserName)
            {
                _id = _node.SelectSingleNode("id").InnerText;
                break;
            }
        }
        return _id;
    }
