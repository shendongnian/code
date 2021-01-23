    protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        var app = (MainPage)((PhoneApplicationFrame)Application.Current.RootVisual).Content;
        var applicationBar = app.ApplicationBar;
        applicationBar.Buttons.Clear();
        base.OnElementPropertyChanged(sender, e);
    }
