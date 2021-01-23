    public LoginResult Login (
        [XmlElement(Namespace = "")] string user,
        [XmlElement(Namespace = "")] string password,
        [XmlElement(Namespace = "")] string client,
        [XmlElement(Namespace = "")] string language)
    {
        return new LoginResult() {
            ResultCode = 0,
            SessionId = user + "-" + password + "-" + client + "-" + language
        };
    }
