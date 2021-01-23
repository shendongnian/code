    string Requete = "select * from Agent where Login = @login and PPR = @ppr";
    SqlDataAdapter da = new SqlDataAdapter(Requete, Connection);
    da.Parameters.Add("@login", SqlDbType.NVarChar, 50, UserLogin.Text);
    da.Parameters.Add("@ppr", SqlDbType.NVarChar, 50, UserPass.Text);
    DataSet Ds = new DataSet();	
    da.Fill(Ds);
