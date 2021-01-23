    using (SqlConnection myConnection = new SqlConnection())
    {
 
        // Create the query
        String myQuery = "INSERT INTO Player  (registrationID,  firstName,  lastName,  phoneNumber,  Address,  dateOfBirth) " +
                   " VALUES (@RegistrationID, @FirstName, @LastName, @PhoneNumber, @Address, @DateOfBirth)";
        //The connectionString can be found in the properties table of the database
        myConnection.ConnectionString = "Data Source=C:/Users/User/Documents/Visual Studio 2012/Projects/ADO_LINQ/ADO_LINQ/App_Data/MyDatabase.sdf";
        //Initialuze the command
        SqlCommand myCommand = new SqlCommand(myQuery, myConnection);
        myCommand.CommandType = CommandType.Text;
        // Here you add the values for the parameters in the query
        myCommand.Parameters.Add("@RegistrationID", SqlDbType.VarChar).Value = registrationID;
        myCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = firstName;
        myCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = lastName;
        myCommand.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = phoneNumber;
        myCommand.Parameters.Add("@Address", SqlDbType.VarChar).Value = address;
        myCommand.Parameters.Add("@DateOfBirth", SqlDbType.VarChar).Value = dateOfBirth;
       
        //Run the command
        try 
        {
            myConnection.Open();
            int rowsAffected = myCommand.ExecuteNonQuery();
   
            if (rowsAffected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
          
         }
         catch (Exception ex) 
         {
             // Do something with the exception, like logging it so you can review the error 
             return false;
         }
     }
