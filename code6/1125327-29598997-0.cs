    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        using (var client = new System.Net.Http.HttpClient())
        {
            using (var stream = await client.GetStreamAsync(yourUri))
            {
                MemoryStream str = new MemoryStream();
                GifDecoder gd = new GifDecoder();
                ImageTools.ExtendedImage img = new ImageTools.ExtendedImage();
                gd.Decode(img, stream);              //stream means image stream
                JpegEncoder png = new JpegEncoder();
                png.Encode(img, str);
            }
        }
    }
