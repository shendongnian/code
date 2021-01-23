    using (OracleCommand cmd = new OracleCommand(sql, conn))
    {
        cmd.Parameters.Add("FROM_DATE", fromDate);
        cmd.Parameters.Add("DISTRIBUTOR_ID", distributorId);
        using (OracleDataReader reader = cmd.ExecuteReader()) // Bottleneck here
        {
        }
    }
