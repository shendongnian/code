    SqlDataAdapter da = new SqlDataAdapter(); 
    
    SqlCommand command = new SqlCommand("select * from Agent where Login = @login and PPR = @ppr", Connection);
    command.Parameters.Add("@login", SqlDbType.NVarChar, 50, UserLogin.Text);
    command.Parameters.Add("@ppr", SqlDbType.NVarChar, 50, UserPass.Text);
    da.SelectCommand = command;
    DataSet Ds = new DataSet();	
    da.Fill(Ds);
