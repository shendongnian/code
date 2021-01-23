    SqlConnection conn = new SqlConnection();
    conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Conn2"].ConnectionString;
    string sqlquery = "exec proSingle @firstName, @lastName, @streetAddress, @city, @zip, @phone, @email";
    // along with all the other variable you created in stored procedure
    SqlCommand command = new SqlCommand(sqlquery, conn);
    try
    {
        // open the connection to the database.
        conn.Open();
        string FirstName = firstNameTextBox.Text;
        // make sure to use @ variable name
        command.Parameters.AddWithValue("@firstName", FirstName);
        // last name
        string LastName = lastNameTextBox.Text;
        command.Parameters.AddWithValue("@lastName", LastName);
        //add all the Variable as you have been adding but only to command
        command.ExecuteNonQuery();
    }
    catch (System.Data.SqlClient.SqlException exception)
    {
        string msg = "Some information has not been entered. Please go back and correct information.";
    }
    finally
    {
        conn.Close();
    }
