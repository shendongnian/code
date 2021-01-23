    public class AccusoftStamper
    {
        public string Stamp()
        {
                var fileNameOrStream = ... // Get your image from somewhere
                using (var lifetime = AccusoftProvider.ImagXpress) // Replace this with your own license
                {
                    var load = new LoadOptions();
                    // All my images are multipage tiff files
                    var save = new SaveOptions { Format = ImageXFormat.Tiff };
                    save.Tiff.MultiPage = true;
                    using (ImageX image = ImageX.FromFile(lifetime, fileNameOrStream, load))
                    {
                        int offset = 0;
                        int pages = ImageX.NumPages(lifetime, fileNameOrStream);
                        for (int i = 0; i < pages; i++)
                        {
                            image.Page = i + 1;
                            save.Tiff.Compression = image.ImageXData.Compression;
                            var pageStamp = ".." // Get your stamp
                            StampImage(lifetime, pageStamp, image);
                            save.Tiff.UseIFDOffset = offset > 0;
                            save.Tiff.IFDOffset = offset;
                            image.Save(outputFileName, save);
                            offset = save.Tiff.IFDOffset;
                        }
                    }
                }
        }
        private void StampImage(ImagXpress lifetime, string text, ImageX destination)
        {
            using (var processor = new Processor(lifetime, destination))
            {
                int bitsPerPixel = destination.ImageXData.BitsPerPixel;
                if (bitsPerPixel != 24) // we can only paint on a 24 bit image.
                    processor.ColorDepth(24, PaletteType.Optimized, DitherType.NoDither);
                using (var g = destination.GetGraphics())
                using (var font = new Font(FontFamily.GenericMonospace, 16, FontStyle.Bold))
                using (var matrix = new Matrix())
                {
                    try
                    {
                        SizeF textSize = g.MeasureString(text, font);
                        Point location = GetStampLocation(new Size(destination.ImageXData.Width, destination.ImageXData.Height), textSize);
                        // All my stamping is vertically along the left edge
                        matrix.Translate(1, 1);
                        matrix.RotateAt(-90, new PointF(location.X, location.Y));
                        g.Transform = matrix;
                        g.DrawString(text,
                                     font,
                                     Brushes.Black,
                                     location.X, location.Y,
                                     new StringFormat());
                    }
                    finally
                    {
                        destination.ReleaseGraphics();
                    }
                }
                // The BPP may change accoding to Accusofts documentation, so change it back to what is was
                if (bitsPerPixel != destination.ImageXData.BitsPerPixel)
                    processor.ColorDepth(bitsPerPixel, PaletteType.Optimized, DitherType.NoDither);
            }
        }
        public Point GetStampLocation(Size imageSize, SizeF textSize)
        {
            var p = new Point(0, 0);
            // Top Right
            //p.X += destination.ImageXData.Width;
            // Top left
            //p.Y += (int)Math.Round(textSize.Width, MidpointRounding.AwayFromZero);
            // Need to figure out where you want the stamp to be
            return p;
        }
    }
