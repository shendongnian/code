    public static DataTable GetSQLValues(string currentDate)
        {
            SqlParameter[] sqlParams = 
            { 
                new SqlParameter("@currentDate", currentDate)
            };
            return DBHelper.GetTable("MSSQLSPNAME", sqlParams);
        }
