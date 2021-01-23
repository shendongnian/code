    SqlConnection connection = new SqlConnection("data source=LOCALHOST;initial catalog=CVtech;Integrated Security=false;User ID=sa;Password=123");
    SqlDataAdapter da = new SqlDataAdapter(); 
    
    SqlCommand command = new SqlCommand("select * from Agent where Login = @login and PPR = @ppr", connection);
    command.Parameters.Add("@login", SqlDbType.NVarChar, 50);
    command.Parameters["@login"].Value = UserLogin.Text;
    command.Parameters.Add("@ppr", SqlDbType.NVarChar, 50);
    command.Parameters["@ppr"].Value = UserPass.Text;
    da.SelectCommand = command;
    DataSet Ds = new DataSet();	
    da.Fill(Ds);
