    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
            base.OnNavigatedTo(e);
            if (NavigationContext.QueryString.ContainsKey("index"))
            {
                var index = NavigationContext.QueryString["index"];
                var indexParsed = int.Parse(index);
                Pivot.SelectedIndex = indexParsed;
            }
    }
