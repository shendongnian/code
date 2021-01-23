    using (connection)
    {
          DataTable depts = GetUserIDWithDepartments();
          SqlCommand insertCommand = new SqlCommand("usp_UpdateUserDepartment", connection);
          insertCommand.CommandType = CommandType.StoredProcedure;
          insertCommand.Parameters.AddWithValue("@userID", currentUserID);
          SqlParameter tvpParam = insertCommand.Parameters.AddWithValue("@tvpNewDepts", depts);
          tvpParam.SqlDbType = SqlDbType.Structured;
          insertCommand.ExecuteNonQuery();
    }
