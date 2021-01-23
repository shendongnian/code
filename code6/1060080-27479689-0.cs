           I hope your are looking for this result.            
            var wb = new WriteableBitmap(ContentPanel, new TranslateTransform());
            using (var mediaLibrary = new MediaLibrary())
            {
                using (var stream = new MemoryStream())
                {
                    var fileName = string.Format("{0}.jpg", DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss"));
                    wb.SaveJpeg(stream, wb.PixelWidth, wb.PixelHeight, 0, quality);
                    stream.Seek(0, SeekOrigin.Begin);
                    var picture = mediaLibrary.SavePicture(fileName, stream);
                }
            }
