     List<GetNewlyCreatedNavigationsFunction_SP_Map> _query;
                 var function_identity_out = new SqlParameter("Function_identity", SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
                 var controller_identity_out = new SqlParameter("Controller_identity", SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
                 var controllerInFunction_identity_out = new SqlParameter("ControllerInFunction_identity", SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
                 var action_identity_out = new SqlParameter("Action_identity", SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
                 var actionInFunction_identity_out = new SqlParameter("ActionInFunction_identity", SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
                 var function_ParentsFunction_identity_out = new SqlParameter("Function_ParentsFunction_identity", SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
                 _query = dbContext.Database.SqlQuery<GetNewlyCreatedNavigationsFunction_SP_Map>("exec CreateFunctionNavigation @FunctionName, @Hierarchy_Level, @ControllerName, @ActionName, @Function_ParentsFunctionID, @Function_identity out, @Controller_identity out, @ControllerInFunction_identity out, @Action_identity out, @ActionInFunction_identity out, @Function_ParentsFunction_identity out",
                    new SqlParameter("@FunctionName", _entity.FunctionName),
                    new SqlParameter("@Hierarchy_Level", _entity.FunctionHierarchy_Level),
                    new SqlParameter("@ControllerName", _entity.ControllerName),
                    new SqlParameter("@ActionName", _entity.ActionName),
                    new SqlParameter("@Function_ParentsFunctionID", _entity.Function_ParentsFunctionID),
                    function_identity_out,
                    controller_identity_out,
                    controllerInFunction_identity_out,
                    action_identity_out,
                    actionInFunction_identity_out,
                    function_ParentsFunction_identity_out 
                  ).ToList();
