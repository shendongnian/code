    private  bool IsCompanyHavingChoiceYes(int iCompanyId)
        {
            bool bRet = false;
            string commandText = @"SELECT cn.companyId from companies cn 
                       INNER JOIN UserCompany uc ON uc.companyid = cn.companyid 
                       INNER JOIN Users u ON u.userId = uc.userId
                       INNER JOIN Choice c ON c.Email = u.Email And c.Choice = @Choice
                       WHERE cn.CompanyId = @CompanyId;";
            string connectionString = ConfigurationSettings.AppSettings["connectionString"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@CompanyId", iCompanyId);
                command.Parameters.AddWithValue("@Choice", "YES");
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        bRet = reader.HasRows;
                    }
                    return bRet;
                }
                catch (Exception ex)
                {
                    return bRet;
                }
               
            }
        }
