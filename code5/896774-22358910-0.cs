    [WebMethod]
    public bool Resume(Guid instanceId, string bookmarkName, object bookmarkParameter)
    {
        Debug.WriteLine(string.Format("Resume - Service id : {0}", _serviceId));
        WorkflowDescriptor descriptor;
        using (var store = new DisposableStore())
        {
            var instance = WorkflowApplication.GetInstance(instanceId, store.Store);
            descriptor = WorkflowLocator.GetWorflowFromIdentity(instance.DefinitionIdentity);
        }
        // We have to create a new store at this point, can't use the same one !!!
        using (var store = new DisposableStore())
        {
            var wfApp = new WorkflowApplication(descriptor.Activity, descriptor.Identity);
            ConfigureWorkflowApplication(wfApp, store.Store);
            wfApp.Load(instanceId);
            var sync = new AutoResetEvent(false);
            wfApp.ResumeBookmark(bookmarkName, bookmarkParameter);
            wfApp.Unloaded = x => sync.Set();
            sync.WaitOne();
        }
        return true;
    }
