    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        string parameterValue = NavigationContext.QueryString["parameter"];   
        int id = Int32.Parse(parameterValue);
        var yourItem = _storage.GetById(id);
    }
