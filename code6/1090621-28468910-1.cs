    public UserInfo GetUserInfo(string username, string password)
    {
        XDocument doc = XDocument.Load(@"K:\Sem2\Software Development in Application Frameworks\test stuff\text\loginDetails.xml");
    
        return doc.Descendants("id")
                    .Where(id => (string)id.Attribute("username") == username 
                            && (string)id.Attribute("password") == password)
                    .Select(s => new UserInfo
                    {
                        username = (string)s.Attribute("username"),
                        password = (string)s.Attribute("password"),
                        email = (string)s.Attribute("email"),
                        question = (string)s.Attribute("question"),
                        answer = (string)s.Attribute("answer")
                    })
                    .FirstOrDefault();
    }
