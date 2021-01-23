    loadingElement.Visible = true;
    Task.Factory.StartNew(() =>
                           {
                               this.SearchCommand.Execute(null);
                           })
                           .ContinueWith(t =>
                           {
    			   MyUIElement = task.Result; // Update your UI here.
                               if (t.IsCompleted)
                               {
                                   t.Dispose();
                               }
                           }, TaskScheduler.FromCurrentSynchronizationContext());
