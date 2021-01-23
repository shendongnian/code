    public string[] GetPasswordAndId(string UserName)
    {
        XDocument xDoc = XDocument.Load("Users.xml");
        XmlNodeList _users = xDoc.SelectNodes("//users/user");
        string[] _pwdAndId = new string[2];
        foreach (XmlNode _node in _users)
        {
            if (_node.SelectSingleNode("username").InnerText == UserName)
            {
                _pwdAndId[0] = _node.SelectSingleNode("id").InnerText;
                _pwdAndId[1] = _node.SelectSingleNode("password").InnerText;
                break;
            }
        }
        return _pwdAndId ;
    }
