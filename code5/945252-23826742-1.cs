    if (null != sqlClass.Reader)
    {
        while (sqlClass.Reader.Read())
        {
            data = sqlClass.Reader.GetString(0);
        }
    }
