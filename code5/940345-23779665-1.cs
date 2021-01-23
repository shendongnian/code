    string commandText = @"SELECT cn.companyName from companies cn 
                           INNER JOIN UserCompany uc ON uc.companyid = cn.companyid 
                           INNER JOIN Users u ON u.userId = uc.userId
                           INNER JOIN Choice c ON c.Email = u.Email And c.Choice = @Choice
                           WHERE cn.CompanyName = @CompanyName;";
    string connectionString = ConfigurationSettings.AppSettings["connectionString"];
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(commandText, connection);        
        
        command.Parameters.AddWithValue("@Choice", "YES");
        command.Parameters.AddWithValue("@CompanyName", "currentCompanyName");
        try
        {
            connection.Open();
            command.ExecuteNonQuery();
            
        }
        catch (Exception ex)
        {
           //handle exception
        }
    }
