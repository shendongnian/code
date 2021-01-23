    int p = (int)ExecutionStatus.Pending;
    int i = (int)OutputStatus.InProcess;
    int n = (int)OutputStatus.New;
    
    using (var ctx = ContextManager.GetContext())
    {
            var executions = from e in ctx.Executions
                             join o in ctx.Outputs on e.ExecutionID equals o.ExecutionID into outputs
                             where e.Status == p &&
                                                outputs.All(o => o.Status != i && o.Status != n)
                             select e;
    }
