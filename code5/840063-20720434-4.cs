    public static class StoredProcedures
    {
        public static DataSet GetKeyTables()
        {
            return SqlDBHelper.ExecuteMultiSelectCommand(
                    "Sp_Get_Key_Tables", 
                    CommandType.StoredProcedure);
        }
    
        public static DataSet GetFoobars()
        {
            return SqlDBHelper.ExecuteMultiSelectCommand(
                    "Sp_Get_Foobars", 
                    CommandType.StoredProcedure);
       }
    }
