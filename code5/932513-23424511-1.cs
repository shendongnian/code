    loadingElement.Visible = true;
    Task.Factory.StartNew(() =>
                           {
                               this.SearchCommand.Execute(null);
                           })
                           .ContinueWith(t =>
                           {
    			              MyUIElement = t.Result; // Update your UI here.
                           }, TaskScheduler.FromCurrentSynchronizationContext());
