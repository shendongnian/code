    private void PageCreate_Click(object sender, RoutedEventArgs e)
    {
        using (var ctx = GetClientContext())
        {
            PagesManager.CreatePublishingPage(ctx, "Hello from WPF.aspx", "BlankWebPartPage.aspx");
        }
    }
