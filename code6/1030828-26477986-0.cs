    public IList<string> ExecuteRule(string rule) {
        var found = new List<string>();
        using (var cnx = new SqlConnection(connectionString)) 
            using (var cmd = new SqlCommand(rule, cnx)) {
                cmd.CommandType = CommandType.Text;
                
                // Make sure to add values to parameters whenever required by your query.
                // e.g. cmd.Parameters.AddWithValue("@paramName", value);
                using (var dr = cmd.ExecuteReader()) 
                    if (dr.HasRows)
                        while (dr.Read()) 
                            if (!dr.IsDBNull(0)) 
                                found.Add(dr.GetStringValue(0));                                        
            }   
        return found;         
    }
