    private bool btnResolved = true;
    async private void btnMessageDisplay_Click(object sender, RoutedEventArgs e)
    {
        if (!btnResolved) return;
        btnResolved = false;
        msg.Content = "Hello Friends...";
        msg.Title = "Message";
        await msg.ShowAsync();
        btnResolved = true;
    }
