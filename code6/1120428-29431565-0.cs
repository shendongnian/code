    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
           string parameter = string.Empty;
        if (NavigationContext.QueryString.TryGetValue("parameter", out parameter)) {
            this.label.Text = parameter;
        }
    }
