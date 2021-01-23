    // popup member
    private Popup popup;
    // creates popup
    private Popup CreatePopup()
    {
        // text
        TextBlock tb = new TextBlock();
        tb.Foreground = (Brush)this.Resources["PhoneForegroundBrush"];
        tb.FontSize = (double)this.Resources["PhoneFontSizeMedium"];
        tb.Margin = new Thickness(24, 32, 24, 12);
        tb.Text = "Custom toast message";
        // grid wrapper
        Grid grid = new Grid();
        grid.Background = (Brush)this.Resources["PhoneAccentBrush"];
        grid.Children.Add(tb);
        grid.Width = this.ActualWidth;
        // popup
        Popup popup = new Popup();
        popup.Child = grid;
        return popup;
    }
    // hides popup
    private void HidePopup()
    {
        SystemTray.BackgroundColor = (Color)this.Resources["PhoneBackgroundColor"];
        this.popup.IsOpen = false;
    }
    // shows popup
    private void ShowPopup()
    {
        SystemTray.BackgroundColor = (Color)this.Resources["PhoneAccentColor"];
        if (this.popup == null)
        {
            this.popup = this.CreatePopup();
        }
        this.popup.IsOpen = true;
    }
    // shows and hides popup with a delay
    private async void ButtonClick(object sender, RoutedEventArgs e)
    {
        this.ShowPopup();
        await Task.Delay(2000);
        this.HidePopup();
    }
