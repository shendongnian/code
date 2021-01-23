    protected void Update_Spend(object sender, System.EventArgs e)
    {
      SqlConnection SQLConn = new SqlConnection (@"Data Source=RFMMailServ;Database=Acquiring;User Id=sa;Password=+RFM@Pr0300k+;");
      SqlCommand cmdUpdate = new SqlCommand("UpdatetblRPT_Spend", SQLConn);
      cmdUpdate.CommandType = CommandType.StoredProcedure;
      cmdUpdate.Parameters.Add("@Month", SqlDbType.Int).Value = int.Parse(slMonth.SelectedValue);
      cmdUpdate.Parameters.Add("@Year", SqlDbType.VarChar).Value = slYear.SelectedValue;
      SQLConn.Open();
      cmdUpdate.ExecuteNonQuery();
      LastMsg.Text = "Spend updated successfully.";
   }
