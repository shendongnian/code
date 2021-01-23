    catch (Exception exc)
    {
        Logger.Write(string.Format("There was an exception while preparing execution data 
                                    for user ID: {0}. Operation ID: {1}", 
                                    WorkflowData.Get(context).SecurityID, 
                                    context.ActivityInstanceId), "Workflow, 3, 305,
                                    TraceEventType.Warning, "PrepareDataActivity");
    }
