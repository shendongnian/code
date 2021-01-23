    SqlConnection conn = new SqlConnection("Data Source = HAMAAD-PC\\SQLEXPRESS ; Initial Catalog = BloodBank; Integrated Security = SSPI ");
    try
    {
       conn.Open();
       SqlCommand query = new SqlCommand("insert into City values('" + txtCity.Text + "')", conn);
       var rowsAffected = query.ExecuteNonQuery();
       
       if (rowsAffected == 1)
       {
          MessageBox.Show("Saved....!");
       }
       else
       {
          MessageBox.Show("Not saved.....");
       }
    }
    catch (Exception ex)
    {
       MessageBox.Show("Failed....." + ex.Message);
    }
