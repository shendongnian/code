    protected List<int> GetIds(string Type, string Sub, IEnumerable<int> types)
    {
        var result = new List<int>();
    
        using (SqlConnection cs = new SqlConnection(connstr))
        using (SqlCommand select = new SqlCommand("spUI_LinkedIds", cs))
        {
            select.CommandType = System.Data.CommandType.StoredProcedure;
            //Don't use AddWithValue! Be explicit about your DB types
            // I had to guess here. Replace with the actual types from your database
            select.Parameters.Add("@Type", SqlDBType.VarChar, 10).Value = Type;
            select.Parameters.Add("@Sub", SqlDbType.VarChar, 10).Value = Sub;
            var TransID = select.Parameters.Add("@TransId", SqlDbType.Int);
            cs.Open();
    
            foreach(int type in types)
            {
                TransID.Value = type;
                SqlDataReader dr = select.ExecuteReader();
                while (dr.Read())
                {
                    result.Add((int)dr["LinkedId"]);
                }
            }
        }
        return result;
    }
