    protected void Application_AuthenticateRequest(object sender, EventArgs e)
{
    MySqlConnection conn;
    if(Request.IsAuthenticated)
    {
        try 
        {
            conn = new MySqlConnection("server=Cheese;user id=george; password=blah; database=mysql; pooling=false");
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = 
               "SELECT G.Name  FROM Roles R INNER JOIN Groups G ON R.GroupID = G.GroupID INNER JOIN Users U ON  R.UserID = U.UserID AND U.Username = ?";
            cmd.Parameters.Add("UserName",User.Identity.Name);
   	    conn.Open()
	    MySqlDataReader r = cmd.ExecuteReader();
   	    ArrayList groups = new ArrayList();
		
   	    while(r.Read())
            {
                groups.Add(r.GetString(0));
	    }
		
  	    HttpContext.Current.User = new GenericPrincipal(User.Identity, groups.ToArray(typeof(System.String)));
	}
        finally
        {
            conn.Close();
        }
    }
    }
