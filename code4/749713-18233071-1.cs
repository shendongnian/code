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
