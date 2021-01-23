    private async void CurrentWindow_VisibilityChanged(object sender, Windows.UI.Core.VisibilityChangedEventArgs e)
    {
        if (e.Visible)
        {
            // window visible... 
        }
        else
        {
            // window not visible, dispose and do what else needs to be done :)
        }
    }
