    private void GetImage()
    {
        RestClient _Client = new RestClient(BASE_URI);
        RestRequest request = new RestRequest("/api/img/{FileName}");
        request.AddParameter("FileName", "dummy.jpg", ParameterType.UrlSegment);
        _Client.ExecuteAsync(
        request,
        Response =>
        {
            if (Response != null)
            {
                byte[] imageBytes = Response.RawBytes;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(imageBytes);
                bitmapImage.CreateOptions = BitmapCreateOptions.None;
                bitmapImage.CacheOption = BitmapCacheOption.Default;
                bitmapImage.EndInit();
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                Guid photoID = System.Guid.NewGuid();
                String photolocation = String.Format(@"c:\temp\{0}.jpg", Guid.NewGuid().ToString());
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                using (var filestream = new FileStream(photolocation, FileMode.Create))
                encoder.Save(filestream);
                this.Dispatcher.Invoke((Action)(() => { img.Source = bitmapImage; }));
                ;
            }
        });
    }
