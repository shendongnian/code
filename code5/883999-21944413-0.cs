    private void btn_InputConfirm_Click(object sender, EventArgs e)
    {
    
      string strConnection = @"Data Source=F_NOOB-PC\;Initial Catalog=ComShopDB;Integrated Security=True";
      SqlConnection objcon = new SqlConnection (strConnection);
    
      try
      {
          //Writing command//
          string strcmd1 = "SELECT partID,partAvailable FROM Parts WHERE partID LIKE '" + txtbox_ProductSerial.Text + "'AND partAvailable ='yes'";
          System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(strcmd1, objcon);
          System.Data.DataSet ds = new System.Data.DataSet();
          aa.Fill(ds);
      }
      catch ( Exception ex )
      {
        MessageBox.Show (ex.Message);
      }
