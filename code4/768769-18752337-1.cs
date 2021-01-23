    string connection = ConfigurationManager.ConnectionStrings ["lawyersDBConnectionString"].ConnectionString.ToString();
    string sql = "select * from users where userName = @uname and password = @pwd";
     DataSet ds = new DataSet();
     using(SqlConnection con = new SqlConnection(connection))
     using(SqlCommand cmd = new SqlCommand(sql, con))
     {
        con.Open();
        cmd.Parameters.AddWithValue("@uname", username);
        cmd.Parameters.AddWithValue("@pwd", password);
        
        using(SqlDataAdapter da = new SqlDataAdapter(cmd))
        {
             User user = new User();
             DataRow dr;
             da.Fill(ds);
             dr = ds.Tables[0].Rows[0];
             user.Id = Convert.ToInt16(dr["userID"]);                
             user.FirstName = (string)dr["firstName"];
             user.LastName = (string)dr["lastName"];
             user.Email = (string)dr["email"];
             user.Username = (string)dr["userName"];
             user.Password = (string)dr["password"];
             user.type = (string)dr["type"];
             return user;
        }
    }
