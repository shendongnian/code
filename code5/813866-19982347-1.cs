    try
    {
        SqlDataReader dataReader = comm.ExecuteReader();
        while (dataReader.Read())
        {
            promoCodeValues.Add(new PromotionalCodeValue(dataReader));
        }
    }
    finally
    {
        conn.Close();
    }
    
    return promoCodeValues.Distinct(new PromotionalCodeEqualityComparer());
