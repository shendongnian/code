        App.Current.Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() =>
                            { this.BusyMessage = "Retreiving data..."; }));
        
        // Do Something 
        
        
       App.Current.Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() =>
                        { this.BusyMessage = "Filtering  data..."; }));
       
       // Do Something
