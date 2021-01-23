    internal static bool ExecuteProc(string sql, List<SqlParameter> paramList = null)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection (GetConnectionString()))
            {                    
               DynamicParameters dp = new DynamicParameters();
               if(paramList != null)
                   foreach (SqlParameter sp in paramList)
                       dp.Add(sp.ParameterName, sp.SqlValue, sp.DbType);
               conn.Open();
               return conn.Execute(sql, dp, commandType: CommandType.StoredProcedure) > 0;
            }
        }
        catch (Exception e)
        {
            //do logging
            return false;
        }
}
