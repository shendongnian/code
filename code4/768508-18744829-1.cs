    private IEnumerable<DAO.User> ConvertToUsers(DataTable dt)
    {
      var users = new List<DAO.User>(dt.Rows.Count);
  
      foreach(var row in dt.AsEnumerable())
      {
         users.Add(new DAO.User()
         {
             Name = row.Field<string>("FULL_NAME"),
             Age = row.Field<int>("AGE")
         });
      }
      return users;
    }
