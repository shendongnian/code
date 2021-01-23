    public static class StoredProcedures
    {
        public static DataSet GetKeyTables()
        {
            DataSet ds = new DataSet();
            ds = SqlDBHelper.ExecuteMultiSelectCommand("Sp_Get_Key_Tables", CommandType.StoredProcedure);
            return ds;
        }
    
        public static DataSet GetFoobars()
        {
            DataSet ds = new DataSet();
            ds = SqlDBHelper.ExecuteMultiSelectCommand(
                                "Sp_Get_Foobars", 
                                CommandType.StoredProcedure);
            return ds;
       }
    }
