    try {
       using (var connection = GetConnection()) {
          using (SqlCommand cmd = connection.CreateCommand()) {
             connection.Open();
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.CommandText = "VerifyInitialization";
             cmd.Parameters.Add(new SqlParameter("@userId", user.Id));
             cmd.Parameters.Add(new SqlParameter("@domainId", user.DomainId));
             //cmd.ExecuteNonQueryAsync(); - This line should be .ExecuteNonQuery()
             cmd.ExecuteNonQueryAsync(); 
          }
       }
    }
    catch (Exception ex) {
       throw new LoginException(LoginExceptionType.Other, ex.Message);
    }
