    if (fromdate != default(DateTime))
    {
        parameters.Add(
            new SqlParameter {
                ParameterName = "@Fromdate",
                SqlDbType = SqlDbType.Date,
                Value = fromdate});
    }
    else
    {
        parameters.Add(
            new SqlParameter {
                ParameterName = "@Fromdate",
                SqlDbType = SqlDbType.Date,
                Value = null});
    }
