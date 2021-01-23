    using (new SecurityDisabler())
    {
         var db= Factory.GetDatabase("master");
         var item = db.Items["/sitecore/content/Home"];         
         // getting the item's workflow reference
         var wf = this.database.WorkflowProvider.GetWorkflow(item);         
         // here we need either to login as a user with appropriate permissions
         // to have access to workflow states/commands or disable security
         wf.Start(item);
    }
