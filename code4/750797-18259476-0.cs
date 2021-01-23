    if( mydataReader.GetOracleValue(n) != DBNull.Value)
    {
        mystringbuilder.Append(mydataReader.GetOracleValue(n).ToString();
    }
    else
    {
        mystringbuilder.Append("");
    }
