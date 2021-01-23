            try
            {
                Microsoft.Win32.SaveFileDialog saveDialog = new Microsoft.Win32.SaveFileDialog();
                saveDialog.Filter = "JPeg Image(*.JPG)|*.jpg|Bitmap Image(*.BMP)|*.bmp|Png Image(*.PNG)|*.png|Gif Image(*.GIF)|*.gif";
                if (saveDialog.ShowDialog().Value == true)
                {
                    Image image2 = new Image();
                    image2.Source = image1.Source;
                    Grid container = new Grid();
                    container.Children.Add(image2);
                    container.Background = new SolidColorBrush(Colors.White);
                    image2.Stretch = Stretch.None;
                    image2.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                    image2.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                    // Get the size of canvas
                    Size size = new Size(image2.Source.Width + 20, image2.Source.Height + 20);
                    // Measure and arrange the surface
                    // VERY IMPORTANT
                    container.Measure(size);
                    container.Arrange(new Rect(size));
                    // BitmapEffect is deprecated and buggy, use Effect instead.
                    image2.Effect = new DropShadowEffect
                    {
                        Color = Colors.Black,
                        ShadowDepth = 5,
                        BlurRadius = 3,
                        Opacity = 1
                    };
                    // Create a render bitmap and push the surface to it
                    RenderTargetBitmap renderBitmap =
                      new RenderTargetBitmap(
                        (int)size.Width,
                        (int)size.Height,
                        96d,
                        96d,
                        PixelFormats.Default);
                    
                    renderBitmap.Render(container);
                    BitmapEncoder encoder = new BmpBitmapEncoder();
                    string extension = saveDialog.FileName.Substring(saveDialog.FileName.LastIndexOf('.'));
                    switch (extension.ToLower())
                    {
                        case ".jpg":
                            encoder = new JpegBitmapEncoder();
                            break;
                        case ".bmp":
                            encoder = new BmpBitmapEncoder();
                            break;
                        case ".gif":
                            encoder = new GifBitmapEncoder();
                            break;
                        case ".png":
                            encoder = new PngBitmapEncoder();
                            break;
                    }
                    // push the rendered bitmap to it
                    encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                    // Create a file stream for saving image
                    using (System.IO.FileStream fs = System.IO.File.Open(saveDialog.FileName, System.IO.FileMode.OpenOrCreate))
                    {
                        encoder.Save(fs);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
