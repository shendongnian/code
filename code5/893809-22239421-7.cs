    using(var Context = new EscapeEntities())
    {
        IQueryable<UserXml> query = Context.UserXml
            .Where(u => u.Password == "Foo")).Enabled();
        List<UserXml> res = query.ToList();
    }
