            var photo = new BitmapImage();
            photo.BeginInit();
            photo.CacheOption = BitmapCacheOption.OnLoad;
            photo.UriSource = new Uri(photoPath);
            photo.EndInit();
            bool isPortrait = photo.Width < photo.Height;
            if (isPortrait)
            {
                var transformedPhoto = new BitmapImage();
                transformedPhoto.BeginInit();
                transformedPhoto.CacheOption = BitmapCacheOption.OnLoad;
                transformedPhoto.UriSource = new Uri(photoPath);
                transformedPhoto.Rotation = Rotation.Rotate270;
                transformedPhoto.EndInit();
                photo = transformedPhoto;
            }
            int width = 6;
            int height = 4;
            double photoScale = Math.Max(photo.Width / (96 * width), photo.Height / (96 * height));
            
            var vis = new DrawingVisual();
            var dc = vis.RenderOpen();
            dc.DrawImage(photo, new Rect
            {
                Width = photo.Width / photoScale,
                Height = photo.Height / photoScale
            });
            
            dc.Close();
            var pdialog = new PrintDialog();
            pdialog.PrintTicket.PageOrientation = PageOrientation.Landscape;
            pdialog.PrintTicket.PageBorderless = PageBorderless.Borderless;
            pdialog.PrintTicket.PageMediaSize = new PageMediaSize(PageMediaSizeName.NorthAmerica4x6);
            pdialog.PrintTicket.Duplexing = Duplexing.OneSided;
            pdialog.PrintTicket.CopyCount = 1;
            pdialog.PrintTicket.OutputQuality = OutputQuality.Photographic;
            pdialog.PrintTicket.PageMediaType = PageMediaType.Photographic;
            pdialog.PrintQueue = new PrintQueue(new PrintServer(), PrinterName);
            pdialog.PrintVisual(vis, "My Visual");
