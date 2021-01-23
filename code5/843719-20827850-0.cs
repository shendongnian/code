    private void UserFullDetail_Load(object sender, EventArgs e)
    {
       string connectionString = "Data Source=PEWPEWDIEPIE\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
       
       DataTable dts3 = new DataTable();
       using (SqlConnection SCScon = new SqlConnection(connectionString))
       {
          string query = "SELECT cDetails, cDetails2, mainCate, PhoneNumber, PersonCharge FROM dbo.ComDet WHERE cName = @CName";
          
          SqlDataAdapter daS = new SqlDataAdapter(query, SCScon);
          daS.SelectCommand.Parameters.Add("@CName", SqlDbType.VarChar, 100).Value = lblcName.Text;
          
          SCScon.Open();
          daS.Fill(dts3);
          SCScon.Close();
       }
       
       // get the first (and hopefully only) row from your DataTable
       DataRow firstRow = dts3.Rows[0];
       
       // fill the values to your labels
       lblFirstDetail.Text = firstRow["cDetails"].ToString();
       lblSecondDetail.Text = firstRow["cDetails2"].ToString();
       lblCategory.Text = firstRow["mainCate"].ToString();
       lblPhoneNumber.Text = firstRow["PhoneNumber"].ToString();
       lblPersonInCharge.Text = firstRow["PersonCharge"].ToString();
    }
    
