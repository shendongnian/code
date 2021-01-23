    using (var ctx = new ClientContext("http://theWebsite"))
    {
        var list = ctx.Web.SiteUserInfoList;
        var users = list.GetItems(new CamlQuery());
        ctx.Load(users);
        ctx.ExecuteQuery();
        // do what you want with the users
    }
