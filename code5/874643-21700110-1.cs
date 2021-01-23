    var context = activityContext.GetExtension<IWorkflowContext>();
    if (context.InputParameters.Contains("Target"))
    {
        if (context.InputParameters["Target"].GetType() == typeof(Entity))
        {
            // create and update are Entity
        }
        else if (context.InputParameters["Target"].GetType() == typeof(EntityReference))
        {
            // delete and some other operations are EntityReference
        }       
    }
    else
    {
        // Started on demand
    }
