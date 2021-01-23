    public async Task MyCommandAsync()
    {
      try
      {
        using (var proxy = new MyProxy())
        {
          var something = await proxy.GetSomethingAsync();
        }
      }
      catch (FaultException<MyFaultDetail> ex)
      {
        // Do something here
      }
    }
    public async override void MyCommandImplementation()
    {
      MyCommandAsync();
    }
