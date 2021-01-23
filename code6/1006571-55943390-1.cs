    sql = sql.Replace(":DISTRIBUTOR_ID", distributorId.ToString())
        .Replace(":FROM_DATE", string.Format("'{0:dd-MMM-yyyy}'", fromDate));
    using (OracleCommand cmd = new OracleCommand(sql, conn))
    {
        using (OracleDataReader reader = cmd.ExecuteReader())
        {
        }
    }
