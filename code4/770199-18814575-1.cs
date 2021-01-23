    using (var conn = new OracleConnection(oradb))
    using (var cmd = conn.CreateCommand())
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "PKG_NAME.INSERT_FUNC";
        cmd.BindByName = true;
        cmd.Parameters.Add("Return_Value", OracleDbType.Int16,
            ParameterDirection.ReturnValue);
        cmd.Parameters.Add("i_description", OracleDbType.Varchar2, 1000,
            promotionEventSetupDetails.PromotionDescription,
            ParameterDirection.Input);
        cmd.Parameters.Add("i_theme", OracleDbType.Varchar2, 80,
            promotionEventSetupDetails.PromotionTheme,
            ParameterDirection.Input);
        cmd.Parameters.Add("o_id", OracleDbType.Varchar2,
            ParameterDirection.Output);
        cmd.Parameters.Add("o_error_msg", OracleDbType.Varchar2,
            ParameterDirection.Output);
        conn.Open();
        using (var dr = cmd.ExecuteReader())
        {
            // do some work here
        }
    }
