        internal static class IconUtilities
        {
            [DllImport("gdi32.dll", SetLastError = true)]
            private static extern bool DeleteObject(IntPtr hObject);
            public static ImageSource ToImageSource(Icon icon)
            {
                Bitmap bitmap = icon.ToBitmap();
                IntPtr hBitmap = bitmap.GetHbitmap();
                ImageSource wpfBitmap = Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
                if (!DeleteObject(hBitmap))
                {
                    throw new Win32Exception();
                }
                return wpfBitmap;
            }
        }
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            ImageSource imageSource = IconUtilities.ToImageSource(Properties.Resources.love);
            this.Icon = imageSource;
            //System.Drawing.Icon ico = Properties.Resources.love;
            //this.Icon = ico;
        }
