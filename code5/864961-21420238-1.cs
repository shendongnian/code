    static User[] LoadUserDetails()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(InfoList)) ;
        using ( Stream s = File.Open("details.xml",FileMode.Open,FileAccess.Read,FileShare.Read) )
        {
            InfoList instance = (InfoList) serializer.Deserialize(s) ;
            return instance.Users ;
        }
    }
