    using Microsoft.Live;
    private LiveConnectSession _session = null;
    public async Task AuthenticateUserThroughLive()
    {
      try
      {
          LiveAuthClient LCAuth = new LiveAuthClient("<Redirect Domain>");
      
          LiveLoginResult loginResult = await LCAuth.LoginAsync(new string[] { "wl.signin", "wl.basic", "wl.skydrive", "wl.skydrive_update" });
          if (loginResult.Status == LiveConnectSessionStatus.Connected)
          {
              this.LiveSession = loginResult.Session;
          }
      }
      catch (LiveAuthException)
      {
         // Handle exceptions.
      }
    }
