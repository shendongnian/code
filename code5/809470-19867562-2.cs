        var thisConnection = new SqlConnection("Server=ServerIP/Name;Data Source=Database;Initial Catalog=Database;User ID=User;Password=Pass;Trusted_Connection=False");
        thisConnection.Open();
        var updateSql1 = "UPDATE dbo.Customer " +
                         "SET barber = 'I Barber People !' " +
                         "WHERE customerID = 5";
        var UpdateCmd1 = new SqlCommand(updateSql1, thisConnection);
        UpdateCmd1.ExecuteNonQuery();
        thisConnection.Close();
