    public DAO.User GetUserBy(string userId)
    {
       var connString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
       using(var da = new SqlDataAdapter(connString, "SELECT * FROM Users where UserId = @p0")
       {
          da.SelectCommand.Parameters.Add("@p0", userId);
          var dt = new DataTable();
          da.Fill(dt);
    
          DAO.User dbUser = ConvertToUsers(dt).FirstOrDefault();
          return dbUser;
       }
    }
