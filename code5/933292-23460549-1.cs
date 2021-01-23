    public void downloading()
    {
        WebClient webClient = new WebClient();
        webClient.OpenReadCompleted += new   OpenReadCompletedEventHandler(ImageOpenReadCompleted);
        webClient.OpenReadAsync(new Uri("http://przeprawa.swi.pl/cgi-bin/kam.cgi?6&1399042906515&" + Guid.NewGuid()));
        var _progressIndicator = new ProgressIndicator
            {
                IsIndeterminate = true,
                IsVisible = true,
                Text = "Downloading...",
            };
        SystemTray.SetProgressIndicator(this, _progressIndicator);
    }
    private void ImageOpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        if (!e.Cancelled && e.Error == null)
        {
            BitmapImage bmp = new BitmapImage();
            bmp.SetSource(e.Result);
            image1.Source = bmp;
            var _progressIndicator = new ProgressIndicator
            {
                IsVisible = false,
            };
            SystemTray.SetProgressIndicator(this, _progressIndicator);
        }
    }
    public void Refresh(object sender, EventArgs e)
    {
        downloading();
    }
