    var dispatcher = Dispatcher.CurrentDispatcher;
    Debug.Assert(dispatcher == Application.Current.Dispatcher);
    Task.Factory
        .StartNew(
            () => SearchHelper.CacheSearchResults(_service.GetData()))
        .ContinueWith(result => 
        { 
            // is the app's dispatcher still the same?
            Debug.Assert(dispatcher == Application.Current.Dispatcher);
 
            // explicitly use Dispatcher.BeginInvoke, that's what
            // DispatcherSynchronizationContext does behind the scene
            Application.Current.Dispatcher.BeginInvoke(new Action(
                () => UpdateCache(result.Result)));
        }, TaskContinuationOptions.ExecuteSynchronously);
