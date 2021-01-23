        public List<Workflow> GetMyWorkflows(int[] MyRoles)
        {
            using (RapidWorkflowDataContext context = new RapidWorkflowDataContext())
            {
               var query = from w in context.WorkflowRoles
                        where MyRoles.Contains((int)w.RoleID)
                        select w.WorkflowID ?? 0;
   
               var distinctWorkflows = query.Distinct();
               return distinctWorkflows.ToList();
            }
        }
<!--
         // int[] myWorkflowIDs = new int[] { };
            RapidWorkflowDataContext context = new RapidWorkflowDataContext();
                var query = from w in context.WorkflowRoles
                            where MyRoles.Contains((int)w.RoleID)
                            select w.WorkflowID;
                var distinctWorkflows = query.Distinct();
               int[] myWorkflowIDs = query.ToArray();
                return myWorkflowIDs;
