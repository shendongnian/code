    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        this.KeyDown += Strona_KeyDown;
    }
    private void Strona_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == Windows.System.VirtualKey.Enter)
        {
            this.Focus(FocusState.Pointer);
        }
    }
