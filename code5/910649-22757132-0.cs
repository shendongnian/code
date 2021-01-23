    public IEnumerable<CustomerSummary> GetAll(SqlConnection conn)
    {
        var result = new List<CustomerSummary>();
    
        try
        {
            SqlCommand cmd = new SqlCommand("GetAll", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataReader sdr;
            conn.Open();
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                var cs = new CustomerSummary();
    
                if (sdr.IsDBNull(sdr.GetOrdinal("ContactName")) != true)
                {
                    cs.ContactName = sdr["ContactName"].ToString();
                }
    
                // repeat the above if-block to add more info if needed...
    
                // add the CustomerSummary to the result
                result.Add(cs);
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            conn.Close();
        }
    
        return result;
    }
