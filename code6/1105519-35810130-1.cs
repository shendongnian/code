    protected void Button1_Click(object sender, EventArgs e)
    {
        
    SqlConnectioncon=newSqlConnection(ConfigurationManager.ConnectionStrings["CRMConnectionString"].ConnectionString);
 
       String SQL = "SELECT UserName,Password FROM Login";
       SqlDataAdapter Adpt = new SqlDataAdapter(SQL, con);
       DataSet login = new DataSet();
       Adpt.Fill(login);
 
       foreach (DataRow dr in login.Tables[0].Rows)
       {
           Label3.Text += login.Tables[0].Rows[0]["USerName"].ToString() + "<br />";
           Label4.Text += login.Tables[0].Rows[1]["Password"].ToString() + "<br />";
       }
      }
