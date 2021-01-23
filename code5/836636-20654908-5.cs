    protected void Application_Start(object sender, EventArgs e)
    {
      Application.Lock();
      try
      {
        var myContainer = Application["EntLibContainer"] as IUnityContainer;
        if (myContainer == null)
        {
          myContainer = new UnityContainer();
          myContainer.AddExtension(new EnterpriseLibraryCoreExtension());
          // Add your own custom registrations and mappings here as required
          Application["EntLibContainer"] = myContainer;
        }
      }
      finally
      {
        Application.UnLock();
      }
    }          
