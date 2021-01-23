        private void slider1_ValueChanged(object sender, RoutedEventArgs e) 
        {
            using (System.Drawing.Bitmap b = (System.Drawing.Bitmap)this.ParentWindow.Document.Bitmap.Clone(new RectangleF() { Width = (int)this.ParentWindow.Document.Bitmap.Width, Height = (int)this.ParentWindow.Document.Bitmap.Height, X = 0, Y = 0 }, this.ParentWindow.Document.Bitmap.PixelFormat))
            {
                this.ParentWindow.SetPixels(b, AdjustmentTypes.Brightness, Convert.ToInt32(this.slider1.Value));
                var hbitmap = b.GetHbitmap(); //create variable so we don't orphan the object
                BitmapSource m = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()); //use variable
                this.ParentWindow.image1.Source = m;
                this.NewBitmap = (System.Drawing.Bitmap)b.Clone();
                hbitmap.DeleteObject(); //delete gdi object
            }
        }
