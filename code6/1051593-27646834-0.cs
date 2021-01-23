    var adunit = new Microsoft.AdMediator.WindowsPhone8.AdMediatorControl
    {
        Name = "AdMediator_XXXXXX",
        Id = "AdMediator-Id-XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
        Width = 480,
        Height = 80,
        HorizontalAlignment = HorizontalAlignment.Left,
        VerticalAlignment = VerticalAlignment.Top,
        Visibility = App.SettingsViewModel.IsTrial ? Visibility.Visible : Visibility.Collapsed
    };
