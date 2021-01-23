    public override bool Enabled
    {
      get
      {
        return Application.Current.Dispatcher.Invoke(() => (ISomethingView) View).ViewModel.Enabled;
      }
    }
