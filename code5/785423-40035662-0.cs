     public static SqlParameter Parameter( SqlDbType dbtype,  string ParameterName, string Value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = ParameterName;
            param.SqlDbType = dbtype;
            param.SqlValue = Value;
            return param;
            // cmd.Parameters.Add(param);
        }
