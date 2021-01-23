    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        var xmlDataSource = new XmlDataSource();
        var sigCol = new SignalCollection(xmlDataSource);
        var allSignals = await sigCol.GetData(false, false, "UA");
        ObservableCollection<IssueDescription> signalsWithCoords = new ObservableCollection<IssueDescription>();
        foreach (var signal in allSignals)
        {
            if (signal.Coords != null)
            {
                signalsWithCoords.Add(signal);                    
            }
        }
        MapItemsControl PushpinCol = MapExtensions.GetChildren(map1).FirstOrDefault(x => x is MapItemsControl) as MapItemsControl;
        PushpinCol.ItemsSource = signalsWithCoords;
    }
