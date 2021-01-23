    var teacher = "Mrs Hart";
    var grades = new[]{ "1st", "2nd", "3rd", "4th", "5th" };
    var sql = "INSERT INTO tbl_TeacherInfo (Teacher,Grade) "
            = "VALUES (@Teacher, @Grade)";
    using (var conn = new SqlConnection(/* connectionString */))
    {
      conn.Open(); // Open once and share it
      // share the command
      using (var cmd = new SqlCommand(sql, conn))
      {
        // assign the shared value across all queries, and
        // add a placeholder for the revolving parameter
        cmd.Parameters.AddWithValue("@Teacher", teacher);
        cmd.Parameters.AddWithValue("@Grade", String.Empty); // placeholder
        // iterate over the grades (1st, 2nd, etc.)
        foreach (var grade in grades)
        {
          cmd.Parameters["@Grade"].Value = grade; // change @Grade
          cmd.ExecuteNonQuery(); // Execute with these two values
        }
      }
      conn.Close(); // cleanup
    }
