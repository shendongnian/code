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
                
                m.WaitOne();
                flowerImage = new BitmapImage(new Uri("pack://siteOfOrigin:,,,/" + filename));
                m.ReleaseMutex();
                isLoaded = true;
                OnPropertyChanged("FlowerImage");
            }
