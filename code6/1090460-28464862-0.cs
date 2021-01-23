        var query = (from c in dataContext.Users
                     where c.username == login && c.password == password
                     select c).FirstOrDefault();
        if (query!=null)
        {
            return query;
        }
        else
        {
            throw new NullReferenceException("Empty query!");
        }
