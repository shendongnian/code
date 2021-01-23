    public static class StoredProcedureManager
    {
        public static Dictionary<string, string> Procedures = new Dictionary<string, string>();
        static StoredProcedureManager()
        {
             procedures.Add("GetEmployeeDetails", "sp_GetEmployeeDetails");
             procedures.Add("UpdateEmployeeName", "sp_updateEmployeeName");
             // you can statically type these names or load them from file or database 
             . . .
        }
    }
