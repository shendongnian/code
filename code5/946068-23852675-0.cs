    private void OnTextChanged(object sender, RoutedEventArgs e)
    {
        if (IsFirstload)
        {
            IsFirstLoad = false;
            return;
        }
        if (IsFileUpToDate != false)
        {
            IsFileUpToDate = false;
        }
    }
