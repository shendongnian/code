        public List<int> GetMyWorkflows(int[] MyRoles)
        {
            using (RapidWorkflowDataContext context = new RapidWorkflowDataContext())
            {
               var query = from w in context.WorkflowRoles
                        where MyRoles.Contains((int)w.RoleID)
                        select w.WorkflowID ?? 0;
                        // select w;  to return a List<WorkFlow>
   
               var distinctWorkflows = query.Distinct();
               return distinctWorkflows.ToList();   // ToList because we are closing the Context
            }
        }
