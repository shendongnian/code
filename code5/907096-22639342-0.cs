    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
     {
    this.SaveState(e);  // <- first line
     }
    protected override void OnNavigatedTo(NavigationEventArgs e)
     {
    this.RestoreState();  // <- second line
     }
