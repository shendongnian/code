    var today = DateTime.Today; // Or maybe use DateTime.Now
    // Use parameterized SQL rather than string concatenations
    string sql = "select todate from Employee where EmpCode=@EmpCode";
    using (var conn = new SqlConnection(...))
    {
        conn.Open();
        using (var command = new SqlCommand(sql, conn))
        {
            command.Parameters.Add("@EmpCode", SqlDbType.VarChar).Value = code;
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    DateTime date = reader.GetDateTime(0);
                    if (today > date)
                    {
                        // Do something
                    }
                }
            }
        }
    }
