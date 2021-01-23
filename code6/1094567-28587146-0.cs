    private string GenerateMessage(SqlException ex)
    {
        StringBuilder builder = new StringBuilder();
        foreach (SqlError error in ex.Errors)
        {
            builder.Append(error.ToString());
        }
        return builder.ToString();
    }
