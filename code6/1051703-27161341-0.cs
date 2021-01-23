    public bool CreateUserAccount(string firstName, string lastName, string aboutUser, string email, string password, 
        string addressLine1, string addressLine2, string city, string postcode, string contactNumber)
    {
        bool registered = false;
        try
        {
            connection = OpenSqlConnection();
            command = new SqlCommand(CREATE_USER_ACCOUNT, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue(FIRST_NAME, firstName);
            command.Parameters.AddWithValue(LAST_NAME, lastName);
            command.Parameters.AddWithValue(ABOUT_USER, aboutUser);
            command.Parameters.AddWithValue(USER_EMAIL, email);
            command.Parameters.AddWithValue(USER_PASSWORD, password);
            command.Parameters.AddWithValue(ADDRESS_LINE_1, addressLine1);
            command.Parameters.AddWithValue(ADDRESS_LINE_2, addressLine2);
            command.Parameters.AddWithValue(CITY, city);
            command.Parameters.AddWithValue(POSTCODE, postcode);
            command.Parameters.AddWithValue(CONTACT_NUMBER, contactNumber);
            registered = Convert.ToBoolean(command.ExecuteNonQuery());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return registered;
    }
