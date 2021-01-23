    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
            base.OnNavigatedTo(e);
            if (NavigationContext.QueryString.ContainsKey("item"))
            {
                var index = NavigationContext.QueryString["item"];
                var indexParsed = int.Parse(index);
                Pivot.SelectedIndex = indexParsed;
            }
    }
