    List<string> names = new List<string> { "john", "brian", "robert" };
    string commandText = "DELETE FROM Students WHERE name IN ({0})";
    string[] paramNames = names.Select(
        (s, i) => "@tag" + i.ToString()
    ).ToArray();
    string inClause = string.Join(",", paramNames);
    using (var command = new SqlCommand(string.Format(commandText, inClause)))
    {
        for (int i = 0; i < paramNames.Length; i++)
        {
            command.Parameters.AddWithValue(paramNames[i], names[i]);
        }
        int deleted = command.ExecuteNonQuery();
    } 
