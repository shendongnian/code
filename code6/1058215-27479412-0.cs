    [WebMethod]
    public List<Users> GetUser()
    {
        var factory = SessionFactory.Instance;
        using (var session = factory.OpenSession())
        {
            return session.QueryOver<Users>().Fetch(u => u.Role).List();
        }
    }
