    protected void SaveButton_Click(object sender, EventArgs e)
    {
        string connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\ASPNETDB.MDF;Integrated Security=True;User Instance=True";
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
    
            string query = 
            "UPDATE aspnet_PersonalInformation Set FirstName=@firstName, LastName=@lastName, StudentNumber=@studentNo, DateOfBirth=@dob where aspnet_PersonalInformation.UserId = @userId";
    
            SqlCommand cmd=new SqlCommand(query,con); 
    
            string userId = "Bob";
           
            cmd.Parameters.AddWithValue("@firstName", FirstName.Text);
            cmd.Parameters.AddWithValue("@lastName", LastName.Text);
            cmd.Parameters.AddWithValue("@studentNo", StudentNumber.Text);
            cmd.Parameters.AddWithValue("@dob", DateOfBirth.Text);
            cmd.Parameters.AddWithValue("@userId", userId);
    
            Int32 rowsAffected = 0;
            try
            {
               rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               // print out ex.Message to figure out what went wrong
            }
        }
    }
