    Get["/fax.html"] = p =>
    {
        FaxModel model = new FaxModel();
    
        var foundType = processes.Where(proc => proc.GetType().ToString().Contains("FaxServer"));
        if(foundType.First() != null)
        {
            bool enabled = Boolean.Parse(WorkflowSettings.GetValue(foundType.First().GetProcessName(), "Enabled"));
            bool deleteAfterSuccess = Boolean.Parse(WorkflowSettings.GetValue(foundType.First().GetProcessName(), "DeleteWorkflowItemsAfterSuccess"));
    
            model.EnableFaxes = enabled;
            model.DeleteFaxes = deleteAfterSuccess;
        }
    
        return View["fax.html", model];
    };
