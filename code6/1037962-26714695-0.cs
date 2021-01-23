     image1.Source = new BitmapImage(new Uri("http://www.image.com/image.jpg",     UriKind.RelativeOrAbsolute));
           using (var mediaLibrary = new MediaLibrary())
            {
                using (var stream = new MemoryStream())
                {
                    var fileName = string.Format("Gs{0}.jpg", Guid.NewGuid());
                    bmp.SaveJpeg(stream, bmp.PixelWidth, bmp.PixelHeight, 0, 100);
                    stream.Seek(0, SeekOrigin.Begin);
                    var picture = mediaLibrary.SavePicture(fileName, stream);
                    if (picture.Name.Contains(fileName)) return true;
                }
            }
