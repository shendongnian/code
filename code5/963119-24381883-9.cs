     private void Save_click(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)vp.ActualWidth, (int)vp.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(vp);
            PngBitmapEncoder png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(rtb));
            string tempFilename = @"g:\mycanvas1.png";
            using (Stream stm = File.Create(tempFilename))
            {
                png.Save(stm);
            }
        }
