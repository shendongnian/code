        public static void SetLimitedImage(UIElement element, string value)
        {
            element.SetValue(LimitedImageProperty, value);
        }
        public static string GetLimitedImage(UIElement element)
        {
            return (string) element.GetValue(LimitedImageProperty);
        }
        AsyncLock imageLock = new AsyncLock();
        private static async void LimitedImagedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Image currentImage = d as Image;
            object dataContext = currentImage.DataContext;
            string uri = e.NewValue as string;
            if (string.IsNullOrEmpty(uri))
            {
                return;
            }
                using (await imageLock.AcquireLock())
                {
                    if (currentImage.DataContext != dataContext)
                    {
                        //Item jhave been recycled
                    }
                    await LoadImage(currentImage, uri);
                }
        }
        
        private static Task<bool> LoadImage(Image image, string uri)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            BitmapImage bitmap = new BitmapImage(new Uri(uri));
            bitmap.ImageOpened += (send, arg) =>
            {
                tcs.SetResult(true);
            };
            bitmap.ImageFailed += (send, arg) =>
            {
                tcs.SetResult(false);
            };
            return tcs.Task;
        }
