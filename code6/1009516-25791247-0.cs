    Task.Factory.StartNew(() =>
    {
      // Code which needs to run asynchronously
    }.ContinueWith(task =>
        {
          Application.Current.Dispatcher.Invoke(new Action(() => 
            {
              // Code in which you are updating UI
            });
        }
