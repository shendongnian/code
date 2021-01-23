    protected void BtnSelect_Click(object sender, EventArgs e)
    {
        SqlDataReader reader;
        String connString = ConfigurationManager
            .ConnectionStrings["RegistrationConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand comm1 = new SqlCommand(
            "SELECT FirstName, LastName, Email FROM UserData " + 
            "WHERE TeacherID = @TeacherID", conn);
        var selectedValue = DropDownList1.SelectedItem.Value;
        var selected = int.Parse(selectedValue);                
            
        comm1.Parameters.Add("@TeacherID", System.Data.SqlDbType.Int);
        comm1.Parameters["@TeacherID"].Value = selected;
        try
        {
            conn.Open();
            reader = comm1.ExecuteReader();
            if (reader.Read())
            {
                txtFirstName.Text = reader["FirstName"].ToString();
                txtLastName.Text = reader["LastName"].ToString();
                txtEmail.Text = reader["Email"].ToString();
            }
            reader.Close();         
        }
        catch(Exception ex)
        {
            dbErrorLabel.Text = ("Error in retrieval " + ex.StackTrace );
        }
        finally
        {
            conn.Close();
        }
    }
