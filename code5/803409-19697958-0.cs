    using (var oCmd = new SqlCommand("getBooking", oCon))
    {
        oCmd.CommandType = CommandType.StoredProcedure;
        using (var oRs = oCmd.ExecuteReader())
        {        
            while (oRs.Read()) {
                // do stuff
            }
        }
    }
