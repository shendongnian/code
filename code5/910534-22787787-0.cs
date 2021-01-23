    public PageOne(MainPage page) {
    _progressIndicator = new ProgressIndicator
                {
                    IsIndeterminate = true,
                    IsVisible = false,
                };
    SystemTray.SetProgressIndicator(page, _progressIndicator);
    }
