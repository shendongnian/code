    private void OnUi (Action action)
    {
        if (_dispatchService == null) 
            _dispatchService = ServiceLocator.Current.GetInstance<IDispatchService>();
            //or _dispatchService  = Application.Current.Dispatcher - whatever is suitable
        if (_dispatchService.CheckAccess())
            action.Invoke ();
        else
            _dispatchService.Invoke(action);
     }
