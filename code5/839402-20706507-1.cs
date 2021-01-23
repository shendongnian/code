    // The InputParameters collection contains all the data passed in the message request.
    if (context.InputParameters.Contains("Target") &&
        context.InputParameters["Target"] is Entity)
    {
        // Obtain the target entity from the input parameters.
        var entity = (Entity)context.InputParameters["Target"];
        entity.Attributes["ABC"] = "TEST";
        // No Need to call Update on the target.  It'll get updated as a part of the Plugin Process
    }
