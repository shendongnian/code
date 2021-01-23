    using (ServerManager serverManager = new ServerManager())
    {
        if (serverManager.ApplicationPools == null)
            return;
    
        for (int i = 0; i < serverManager.Sites.Count; i++)
        {
            Microsoft.Web.Administration.ApplicationPoolCollection appPoolCollection = serverManager.ApplicationPools[i];
        }
        if (serverManager.Sites == null)
            return;
        for (int i = 0; i < serverManager.Sites.Count; i++)
        { 
           Microsoft.Web.Administration.BindingCollection bindingCollection = serverManager.Sites[i].Bindings;
        }
    }
