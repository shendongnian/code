    public static SplashScreen ShowSplashScreen()
    {
      var form = new SplashScreen();
    
      new Thread(() => Application.Run(form)).Start();
    
      return form;
    }
    public override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (InvokeRequired)
        {
          Invoke(() => base.Dispose(true));
          return;
        }
        
        base.Dispose(true);
      }
      else base.Dispose(disposing);
    }
