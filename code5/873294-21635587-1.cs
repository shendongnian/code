    using(SqlConnection conn = new SqlConnection(strConnectionString))
    {
        conn.Open();
        using(SqlTransaction transaction = conn.BeginTransaction())
        {
            // execute first command
            string insertCentreQuery = 
                @"INSERT MEDICALCENTRE (mcType, mcCentre) 
                  VALUES (@NewmcType, @NewmcCentre)
                  SELECT SCOPE_IDENTITY()";
            SqlCommand insertCentreCmd = 
                new SqlCommand(insertCentreQuery, conn, transaction);
            // ...provide command parameters
            int mcID = (int)insertCentreCmd.ExecuteScalar();          
            // execute second command
            string insertUserQuery =
                @"INSERT WINDOWSADMIN (winUsername, winPassword, mcID)
                  VALUES (@userName, @password, @mcID)";
            SqlCommand insertUserCmd = 
                new SqlCommand(insertUserQuery, conn, transaction);
            // ...provide command parameters
            insertUserCmd.ExecuteNonQuery();
            transaction.Commit();
        }   
    }
