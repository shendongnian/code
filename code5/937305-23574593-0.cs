    public override bool Enabled
    {
      get
      {
        return View.Dispatcher.Invoke(() => { return ((ISomethingView)View).ViewModel.Enabled } );
      }
    }
