    public class SafeImage : ContentControl
    {
        private SynchronizationContext uiThread;
        public static readonly DependencyProperty SafePathProperty =
            DependencyProperty.Register("SafePath", typeof (string), typeof (SafeImage),
            new PropertyMetadata(default(string), OnSourceWithCustomRefererChanged));
        public string SafePath
        {
            get { return (string) GetValue(SafePathProperty); }
            set { SetValue(SafePathProperty, value); }
        }
        
        private static void OnSourceWithCustomRefererChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            SafeImage safeImage = o as SafeImage;
            safeImage.OnLoaded(null, null);
            //OnLoaded(null, null);
            if (e.NewValue == null)
                return;
        }
        public SafeImage()
        {
            Content = new Image();
            uiThread = SynchronizationContext.Current;
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }
        private void OnLoaded(object _sender, RoutedEventArgs _routedEventArgs)
        {
            var image = Content as Image;
            if (image == null)
                return;
            var path = SafePath; //(string)GetValue(SafePathProperty);
            //image.Source = new BitmapImage(new Uri(SafePath));
            Debug.WriteLine(path);
            var bitmapImage = image.Source as BitmapImage;
            if (bitmapImage != null)
                bitmapImage.UriSource = null;
            image.Source = null;
            if (String.IsNullOrEmpty(path))
            {
                //image.Source = new BitmapImage { UriSource = new Uri(Constants.RESOURCE_IMAGE_EMPTY_PRODUCT, UriKind.Relative) };
                return;
            }
            // If local image, just load it (non-local images paths starts with "http")
            if (path.StartsWith("/"))
            {
                image.Source = new BitmapImage { UriSource = new Uri(path, UriKind.Relative) };
                return;
            }
            
            {
                var request = WebRequest.Create(path) as HttpWebRequest;
                request.AllowReadStreamBuffering = true;
                request.BeginGetResponse(result =>
                {
                    try
                    {
                        Stream imageStream = request.EndGetResponse(result).GetResponseStream();
                        uiThread.Post(_ =>
                        {
                            
                            if (path != this.SafePath)
                            {
                                return;
                            }
                            if (imageStream == null)
                            {
                                image.Source = new BitmapImage { UriSource = new Uri(path, UriKind.Relative) };
                                return;
                            }
                            bitmapImage = new BitmapImage();
                            bitmapImage.CreateOptions = BitmapCreateOptions.BackgroundCreation;
                            bitmapImage.SetSource(imageStream);
                            image.Source = bitmapImage;
                            //imageCache.Add(path, bitmapImage);
                        }, null);
                    }
                    catch (WebException)
                    {
                        //uiThread.Post(_ =>
                        //{
                        //    image.Source = new BitmapImage { UriSource = new Uri(Constants.RESOURCE_IMAGE_EMPTY_PRODUCT, UriKind.Relative) };
                        //}, null);
                    }
                }, null);
            }
        }
        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            var image = Content as Image;
            if (image == null)
                return;
            var bitmapImage = image.Source as BitmapImage;
            if (bitmapImage != null)
                bitmapImage.UriSource = null;
            image.Source = null;
        }
    }
