    var promoCodeValues = new List<PromotionalCodeValue>();
    
    using(var connection = xxxConnection())
    using(var command = new SqlCommand("GetPromotionalCodeValues", connection))
    {
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Platform", Platform);
        
        connection.Open();
        
        using(var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                promoCodeValues.Add(new PromotionalCodeValue(reader));
            }
        }
    }
    return promoCodeValues.Distinct(new PromotionalCodeEqualityComparer()).ToList();
