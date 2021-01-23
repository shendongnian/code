    async void DataChangedHandler(object sender, Journaling.DataChangeEventArgs args)
    {
      using (args.GetDeferral())
      {
        // Code can safely await in here.
      }
    }
