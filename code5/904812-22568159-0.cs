    protected override void OnInitialized(EventArgs e)
    {
      if (!userHasAccess)
      {
       this.Content = new AccessDenied();
      }
      base.OnInitialized(e);
    }
