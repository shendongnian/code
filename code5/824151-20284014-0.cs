    private async void LoadImage()
            {
                WebClient wc = new WebClient();
    
                await Task.Run(() =>
                    {
                        m.WaitOne();
    
                        FileInfo fi = new FileInfo(filename);
                        if (fi.Exists == false)
                        {
                            wc.DownloadFile(url, filename);
                            wc.Dispose();
                        }
    
                        m.ReleaseMutex();
                    });
                    
                flowerImage = new BitmapImage(new Uri("pack://siteOfOrigin:,,,/" + filename));
                isLoaded = true;
                OnPropertyChanged("FlowerImage");
            }
