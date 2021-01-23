    sqlc = new SqlConnection(ConnectionString);
    SqlCommand cmd = new SqlCommand();
    cmd.CommandType = CommandType.Text;
    cmd.Connection=sqlc;
    string username = HttpContext.Current.User.Identity.Name.ToString();
    cmd.CommandText = @"SELECT RemainedCharge "
                              + " FROM aspnet_Users "
                              + " WHERE UserName = @UserName ";
    cmd.Parameters.Add(new SqlParameter("@UserName", username));
    //string RemainedCharge;
    sqlc.Open();
    
     RemainedChargeLbl.Text =((int) cmd.ExecuteScalar()).ToString();
       
