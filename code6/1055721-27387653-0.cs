     #region Dodgy dodgy hackery. There has to be a better way of doing this ....
     var trace = typeof(System.Workflow.Activities.StateActivity)
                    .Assembly
                    .GetType("System.Workflow.Activities.WorkflowActivityTrace");
    
     var rules = trace.GetProperty("Rules", BindingFlags.NonPublic | BindingFlags.Static)
                    .GetValue(null, null)
                    as System.Diagnostics.TraceSource;
    
     rules.Switch.Level = System.Diagnostics.SourceLevels.Information;
    
     rules.Listeners.Clear();
     rules.Listeners.Add(_traceListener);
     #endregion
