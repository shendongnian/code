    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
       String connString = ConfigurationManager.ConnectionStrings["inventoryConnectionString"].ConnectionString;
       using (SqlConnection con = new SqlConnection(connString))
      {
       con.Open();
       String strSQL = "SELECT EmployeeID, Weight, Amount FROM Supplier where  EmployeeName=@EmployeeName";
       using (SqlCommand cmd = new SqlCommand(strSQL, con)) 
       {
        cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar).Value = TextBox2.Text;
        using (SqlDataAdapter DA = new SqlDataAdapter(cmd))
         {
            DA.SelectCommand = cmd;
            try
                    {
                        DataSet DS = new DataSet();
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
