    async Task LoadData()
    {
        // do some stuff
        var data = await SomeWebCall();
        Deployment.Current.Dispatcher.BeginInvoke( () => {
            MyObservableCollection = data; // or new ObservableCollection(data);
        });
    }
