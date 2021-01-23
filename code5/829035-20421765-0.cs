       private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            System.Drawing.Image imgforms = (System.Drawing.Bitmap)eventArgs.Frame.Clone();
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            MemoryStream ms = new MemoryStream();
            imgforms.Save(ms, ImageFormat.Bmp);
            ms.Seek(0, SeekOrigin.Begin);
            bi.StreamSource = ms;
            bi.EndInit();
            //Using the freeze function to avoid cross thread operations 
            bi.Freeze();
            //Calling the UI thread using the Dispatcher to update the 'Image' WPF control         
            Dispatcher.BeginInvoke(new ThreadStart(delegate
            {
                ImageWebcam.Source = bi; /*frameholder is the name of the 'Image' WPF control*/
            }));     
        }
