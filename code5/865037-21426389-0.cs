    Task.Factory.StartNew(() => { ..Do the background DataTable update.. })
                    .ContinueWith(task => 
                                 {
                                    var dispatcher = Application.Current == null
                                         ? Dispatcher.CurrentDispatcher
                                         : Application.Current.Dispatcher;
    
                                    Action action = delegate()
                                                    {
                                                        //Update UI (e.g. Raise NotifyPropertyChanged on bound DataTable Property)
                                                     };
    
                                   dispatcher.Invoke(DispatcherPriority.Normal, action);
    });
