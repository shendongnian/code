    public string GetUserPassword(string UserName)
    {
        XDocument xDoc = XDocument.Load("Users.xml");
        XmlNodeList _users = xDoc.SelectNodes("//users/user");
        string _pwd = null;
        foreach (XmlNode _node in _users)
        {
            if (_node.SelectSingleNode("username").InnerText == UserName)
            {
                _pwd = _node.SelectSingleNode("password").InnerText;
                break;
            }
        }
        return _pwd;
    }
