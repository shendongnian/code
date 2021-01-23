    await Deployment.Current.Dispatcher.InvokeAsync((async () =>
    {
        List<WallpaperModel> col;
        try
        {
            int day = 0;
            if (mgr.ImageMode == WallpaperChangeMode.RandomMode)
            {
                Random r = new Random();
                day = r.Next(16);
            }
            col = await wl.GetModelsAsync(day, 1, mgr.LastCountryPath, Resolution.PhoneResolutions[3]);
        }
        catch (Exception)
        {
            NotifyComplete();
            return;
        }
    
        Stream s = await wl.DownloadAsync(col[0].Image.UriSource.OriginalString);
        var hlpr = new LockHelper(s);
        await hlpr.TrySetLockAsync(true);
    
    }));
