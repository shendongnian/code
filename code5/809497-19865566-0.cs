    string query = @"SELECT e.*
                     FROM EMP e
                     INNER JOIN Junction j ON e.ID = j.empID
                     WHERE j.skillID = @SkillID";
    int skillID = 5;
    using (var conn = new SqlConnection("connectionString"))
    {
        using (var cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@SkillID", skillID);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    int name = (string)reader["Name"];
                    // etc.
                }
            }
        }
    }
