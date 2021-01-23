    string CS = ConfigurationManager.ConnectionStrings["CTECS"].ConnectionString;
    using (SqlConnection con = new SqlConnection(CS))
    {
        SqlCommand cmd = new SqlCommand(usp_InsertProject, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@project_name", txtName.Text); // you must validate text value before passing
        cmd.Parameters.AddWithValue("@manager_id", currentUser.userID);
    
        con.Open();
        using(SqlDataReader reader = cmd.ExecuteReader())
        {
            if(reader.Read())
            {
               // the error occured in SP
               // reader[0] is error number
               // record[1] is error message
            }
        }
    }
