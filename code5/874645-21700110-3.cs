    var context = activityContext.GetExtension<IWorkflowContext>();
    if (context.InputParameters.Contains("Target"))
    {
        // Started by a trigger
    }
    else
    {
        // Started on demand
    }
            
