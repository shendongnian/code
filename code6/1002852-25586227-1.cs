    FirstUserControl.HideButtonClicked += OnHideButtonClicked;
    
    private void OnHideButtonClicked(object sender, EventArgs args)
    {
        ((MyUsercontrol)sender).Visibility = Visibility.Collapsed;
        SomeOthercontrol.Visibility = Visibility.Visible;
    }
