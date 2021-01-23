    public static class ImageProxyHelper
    {
        public static void GetImageByProxy(string url, Action<BitmapImage> callback)
        {
            if (callback == null) return;
            var client = new WebClient();
            client.DownloadStringCompleted += (sender, args) =>
            {
                if (args.Error == null)
                {
                    var buffer = JsonConvert.DeserializeObject<byte[]>(args.Result);
                    var im = new BitmapImage() { CreateOptions = BitmapCreateOptions.None };
                    im.SetSource(new MemoryStream(buffer));
                    callback(im);
                }
            };
            client.Headers["Url"] = url;
            client.DownloadStringAsync(UrlBuilder("ImageUrlProxy.ashx"));
        }
        public static Uri UrlBuilder(string fragment)
        {
            var uriBuilder = new UriBuilder(Application.Current.Host.Source.Scheme,
                Application.Current.Host.Source.Host,
                Application.Current.Host.Source.Port, fragment);
            return uriBuilder.Uri;
        }
    }
