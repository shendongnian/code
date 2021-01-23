    public void DeleteNavigationFunctionByID(int _FunctionNavigationID)
       {
           using (var dbContext = new FunctionContext())
           {
               List<DeleteFunctionNavigation_SP_Map> _query;
            
               var Action_identity_out = new SqlParameter("Action_identity", SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
               var ActionInFunction_Count_out = new SqlParameter("ActionInFunction_Count", SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
               var Controller_identity_out = new SqlParameter("Controller_identity", SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
               _query = dbContext.Database.SqlQuery<DeleteFunctionNavigation_SP_Map>("exec DeleteFunctionsNavigation @FunctionID, @Action_identity out, @ActionInFunction_Count out, @Controller_identity out",
                         new SqlParameter("@FunctionID", _FunctionNavigationID),
                         Action_identity_out,
                         ActionInFunction_Count_out,
                         Controller_identity_out
               ).ToList();
           }
    }
