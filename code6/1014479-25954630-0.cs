        void exportToImage(double width, double height, Visual visual)
        {
            //this line can not be inside a thread because different thread owns the visual
            string visualData = XamlWriter.Save(visual);
            Thread t = new Thread(() =>
                {
                    var filename = string.Format(@"{0}.png", Guid.NewGuid());
                    var tempFile = System.IO.Path.Combine("c:\\", filename);
                    Rect rect = new Rect(0, 0, width, height);
                    //create a host control to host the visual
                    ContentControl cc = new ContentControl();
                    cc.Content = XamlReader.Parse(visualData);
                    //call Arrange to let control perform layout (important)
                    cc.Arrange(rect);
                    RenderTargetBitmap rtb = new RenderTargetBitmap((int)rect.Right,
                        (int)rect.Bottom, 96d, 96d, System.Windows.Media.PixelFormats.Default);
                    rtb.Render(cc);
                    //endcode as PNG
                    BitmapEncoder pngEncoder = new PngBitmapEncoder();
                    pngEncoder.Frames.Add(BitmapFrame.Create(rtb));
                    //save to memory stream
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    pngEncoder.Save(ms);
                    ms.Close();
                    System.IO.File.WriteAllBytes(tempFile, ms.ToArray());
                });
            //STA is necessary for XamlReader.Parse, and proper rendering
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
