    if (null != sqlClass.Reader && sqlClass.Reader.HasRows)
    {
        while (sqlClass.Reader.Read())
        {
            data = sqlClass.Reader.GetString(0);
        }
    }
