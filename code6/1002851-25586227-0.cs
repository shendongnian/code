    public event EventHandler HideButtonClicked;
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (HideButtonClicked != null)
            HideButtonClicked(this, EventArgs.Empty);
    }
