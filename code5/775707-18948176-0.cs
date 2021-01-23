    private void fetchSoapRows()
    {
        var strings = (txtInput.Text.Split('*')).ToObservable();
        strings
            .ObserveOn(ThreadPoolScheduler.Instance)
            .Subscribe(s=> SoapQueryEngine.Fetch(s));
    }
