    public void OnNext(ObservableArgs args)
    {
        _action?.Invoke(args);
    }
            
