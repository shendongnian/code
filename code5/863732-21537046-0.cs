        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //622Kb: http://www.nasa.gov/sites/default/files/styles/1920x1080_autoletterbox/public/pia17147.jpg?itok=6jErm40V
            //2.7Mb: http://www.nasa.gov/sites/default/files/304_lunar_transit_14-00_ut_0.jpg
            StorageFile imageFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(@"Assets\test3.jpg");
            MemoryStream mz;
            using (var z = await imageFile.OpenStreamForReadAsync())
            {
                if (z.Length > int.MaxValue) return;
                mz = new MemoryStream((int)z.Length);
                var buffer = new byte[4096];
                while (mz.Length < z.Length)
                {
                    var readCount = z.Read(buffer, 0, Math.Min(buffer.Length, (int)(z.Length - mz.Length)));
                    if (readCount <= 0)
                    {
                        throw new NotSupportedException();
                    }
                    mz.Write(buffer, 0, readCount);
                }                
            }
            var bmp = new BitmapImage();
            bmp.SetSource(mz);
            //Deployment.Current.Dispatcher.BeginInvoke(() => img.Source = bmp); // if in another sync context only
            img.Source = bmp;
        }
