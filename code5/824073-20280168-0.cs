    private void ApplicationBarIconButton_Click(object sender, EventArgs e)
            {
                var fileName = String.Format("WmDev_{0:}.jpg", DateTime.Now.Ticks);
                WriteableBitmap bmpCurrentScreenImage = new WriteableBitmap((int)this.ActualWidth, (int)this.ActualHeight);
                bmpCurrentScreenImage.Render(LayoutRoot, new MatrixTransform());
                bmpCurrentScreenImage.Invalidate();
                SaveToMediaLibrary(bmpCurrentScreenImage, fileName, 100);
                MessageBox.Show("Captured image " + fileName + " Saved Sucessfully", "WmDev Capture Screen", MessageBoxButton.OK);
     
                currentFileName = fileName;
            }
     
            public void SaveToMediaLibrary(WriteableBitmap bitmap, string name, int quality)
            {
                using (var stream = new MemoryStream())
                {
                    // Save the picture to the Windows Phone media library.
                    bitmap.SaveJpeg(stream, bitmap.PixelWidth, bitmap.PixelHeight, 0, quality);
                    stream.Seek(0, SeekOrigin.Begin);
                    new MediaLibrary().SavePicture(name, stream);
                }
            }
