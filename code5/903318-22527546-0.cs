    protected void LoginButton_Click1(object sender, EventArgs e)
    {
      int Results = 0;
      using (SqlConnection sc1 = new SqlConnection())
      {
          sc1.ConnectionString = "Data Source=localhost;Initial Catalog=Drug;Integrated Security=True";
          SqlCommand sqlcom = new SqlCommand("user_login",sc1);
          {
             sqlcom.CommandType = CommandType.StoredProcedure;
             sqlcom.Parameters.Add("@UsernameSP", SqlDbType.VarChar, 10).Value = this.txtUserName.Text.Trim();
             sqlcom.Parameters.Add("@PasswordSP", SqlDbType.VarChar, 10).Value = this.txtPwd.Text.Trim();
             sqlcom.Parameters.Add("@OutRes", SqlDbType.Int, 4);
             sqlcom.Parameters["@OutRes"].Direction = ParameterDirection.Output;
             sqlcom.Connection = sc1;
             try
             {
               sc1.Open();
               sqlcom.ExecuteNonQuery();
               Results =(int)sqlcom.Parameters["@OutRes"].Value;
             }
             catch (SqlException ex)
             {
                  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
             }
             finally
             {
                sqlcom.Dispose();
                if (sc1 != null)
                {
                   sc1.Close();
                }
            }
        } 
        if (Results == 0)
           ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "result 0" + "')", true);
        else
        { 
           ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",   "alert('" + "result 1" + "')", true);
           Response.Redirect("/DrugEntry.aspx");
        }
     }
