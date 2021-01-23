     public List<object> Whatever(string prpClass)
     {
        using (var ctx = new ApplicationDbContext())
        {
            if (prpClass == "Blah")
            {
                string queryBlah = @"SELECT ... ";
                var result = ctx.Database.SqlQuery<Blah>(queryBlah).ToList();
                return result.Cast<object>().ToList();
            }
            if (prpClass == "Doh")
            {
                string queryDoh = @"SELECT ... ";
                var result = ctx.Database.SqlQuery<Doh>(queryDoh).ToList();
                return result.Cast<object>.ToList();
            }
            return null;
        }
    }
