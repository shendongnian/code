    public void NullorEmptyParameter(QC.SqlCommand command, string at, string value)
    {
        if (String.IsNullOrEmpty(value))
        {
            command.Parameters.AddWithValue(at, DBNull.Value);
        }
        else
            command.Parameters.AddWithValue(at, value);
    }
