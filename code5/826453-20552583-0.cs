    public void Setup()
    {
        var r = Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView();
        r.QualifierValues.MapChanged += QualifierValues_MapChanged;
    }
    public void Cleanup()
    {
        var r = Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView();
        r.QualifierValues.MapChanged -= QualifierValues_MapChanged;
    }
    void QualifierValues_MapChanged(Windows.Foundation.Collections.IObservableMap<string, string> sender, Windows.Foundation.Collections.IMapChangedEventArgs<string> @event)
    {
        // you can set your own or use the first (default)
        var l = Windows.System.UserProfile.GlobalizationPreferences.Languages.First();
        Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = l;
    }
