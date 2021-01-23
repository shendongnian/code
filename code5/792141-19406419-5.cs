    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        string path = "";
        if (NavigationContext.QueryString.TryGetValue("path", out path))
        {
            if (!string.IsNullOrWhiteSpace(path))
            {
                this.TheImage.Source =
                    new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
            }
        }
    }
