    List<AtsPlatform> GetAtsPlatformByName(int index)
    {
        using (var ctx = new Entities())
        {
            return ctx.Database.SqlQuery<AtsPlatform>("SELECT * FROM dbo.ats" + index)
                               .ToList();
        }
    }
