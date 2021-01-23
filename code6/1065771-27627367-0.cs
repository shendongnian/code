    public static MemberList memList()
    {            
        WebClient atv = new WebClient();
        var data = atv.DownloadString("https://www.somewebsvc.com/memberships");
        MemberList m = Newtonsoft.Json.JsonConvert.DeserializeObject<MemberList>(data);
        foreach (Member mb in m.members)
            {
                string[] names = mb.Name.Split(new char[] { ' ' }, 2);
                mb.FirstName = names[0];
                mb.LastName = names[1];
            }
        return m;
    }
