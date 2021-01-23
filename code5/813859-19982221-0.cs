    public static List<PromotionalCodeValue> GetPromotionalCodeValues(string Platform)
    {
        // This ensures that your connection gets closed even if there's
        // an exception thrown. No need for a try/finally
        using (SqlConnection conn = xxxConnection())
        {
            SqlCommand comm = new SqlCommand("GetPromotionalCodeValues", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Platform", Platform);
            conn.Open();
            List<PromotionalCodeValue> promoCodeValues = new List<PromotionalCodeValue>();
            SqlDataReader dataReader = comm.ExecuteReader();
            while (dataReader.Read())
            {
                promoCodeValues.Add(new PromotionalCodeValue(dataReader));
            }
            promoCodeValues = 
                (from pc in promoCodeValues
                // Group by ID, then choose the first item from each group;
                // This is effectively the same as "DistinctBy" but requires
                // no extra methods or classes.
                group pc by pc.Value into g
                select g.First())
                    .ToList();
            return promoCodeValues;
        }
    }
