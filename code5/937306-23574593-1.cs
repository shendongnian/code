    public override bool Enabled
    {
      get
      {
        return View.Dispatcher.Invoke( () => ((ISomethingView)View).ViewModel.Enabled );
      }
    }
