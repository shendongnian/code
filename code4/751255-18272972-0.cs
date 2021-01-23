    // new private class variable
    private BackgroundWorker _worker = new BackgroundWorker();
    
    // constructor code
    public .ctor()
    {
        _worker.WorkerReportsProgress = true;
        _worker.DoWork += (s, e) =>
        {
            // Loop through each of the tests
            foreach (var testLight in imageDictionary)
            {
                _worker.ReportProgress(1, testLight.Value);
    
                Thread.Sleep(1000);
            }
        }
        _worker.ProgressChanged += (s, e) =>
        {
            var myImage3 = new Image();
            var redLightImage = new BitmapImage();
            redLightImage.BeginInit();
            redLightImage.UriSource = new Uri("red_light.png", UriKind.Relative);
            redLightImage.EndInit();
            myImage3.Stretch = Stretch.Fill;
            myImage3.Source = redLightImage;
    
            ((Image)e.UserState).Source = redLightImage;
        }
    }
