    SPSecurity.RunWithElevatedPrivileges(delegate(){
    using (SPSite currentSite = new SPSite("http://tst:001/sites/Test"))
    {
        using (SPWeb currentWeb = currentSite.OpenWeb())
        {
            string tasksList = "Workflow Tasks";                    
            SPUser delegateTouser = currentWeb.EnsureUser("DOMAIN\\Test2");
            SPListItem listItem = currentWeb.Lists.TryGetList(tasksList).GetItemById(101);
            listItem[SPBuiltInFieldId.AssignedTo] = delegateTouser;
            listItem[SPBuiltInFieldId.WorkflowVersion] = "1";
            listItem.Update();
        }
    }
    });
