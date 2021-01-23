    public dynamic GetLoginValues(String user, String pass)
    {
        using (db = new DCDataContext())
        {
            var x = (from u in db.users
                   join t in db.userTypes on u.type equals t.typeID
                   where u.loginName == user &&
                   u.password == pass &&
                   u.isActive == true
                   select new
                       {
                           u.userID,
                           u.loginName,
                           u.userCode,
                           u.type,
                           u.team,
                           t.typeName
                       }).ToList();
          return x; //returns the list of values
       }
    }
