    private static INavigationService _navservice; // declared at top of class
    
    protected override void Configure(){
       //viewmodel inclusions into container here...
      PrepareViewFirst();
    }
    protected override void PrepareViewFirst(Frame rootFrame)
    {
        _navservice = container.RegisterNavigationService(rootFrame);
    }
 
