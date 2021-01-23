    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
      using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["inventoryConnectionString"].ConnectionString)) {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("SELECT EmployeeID, Weight, Amount FROM Supplier where  EmployeeName=@EmployeeName", con)) {
      cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar).Value = TextBox2.Text;
       using (SqlDataAdapter DA = new SqlDataAdapter(cmd))
         {
            DA.SelectCommand = cmd;
            try
                    {
                        DA.Fill(DS);
                        foreach (DataRow row in DS.Tables[0].Rows)
                        {
                         txtBoxId.Text = row["EmployeeID"].ToString();
                         txtboxw.Text = row["Weight"].ToString();
                         txtboxam.Text = row["Amount"].ToString();
                         }
                    }
                    catch (Exception ex)
                    {
                    }
              }
          }
       }
     }
