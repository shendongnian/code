    public BitmapImage Image
        {
            get
            {
                if (!image_retrieved) getImageAsync();
                return _Image;
            }
        }
    
    private async Task getImageAsync()
        {
            image_retrieved = true;
            _Image = await ImageFactory.CreateImageAsync(ImageFullPath).ConfigureAwait(true);
            this.OnPropertyChanged(() => Image);
        }
    public static async Task<BitmapImage> CreateImageAsync(string filename)
        {
            if (!string.IsNullOrEmpty(filename) && File.Exists(filename))
            {
                try
                {
                    byte[] buffer = await ReadAllFileAsync(filename).ConfigureAwait(false);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(buffer);
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = ms;
                    image.EndInit();
                    image.Freeze();
                    return image;
                }
                catch
                {
                    return null;
                }
            }
            else return null;
        }
    static async Task<byte[]> ReadAllFileAsync(string filename)
        {
            try
            {
                using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
                {
                    byte[] buff = new byte[file.Length];
                    await file.ReadAsync(buff, 0, (int) file.Length).ConfigureAwait(false);
                    return buff;
                }
            }
            catch
            {
                return null;
            }
        }
