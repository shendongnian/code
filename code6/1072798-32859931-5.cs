                byte[] image = GetImage(luckyUrl);
                using (var stream = new MemoryStream(image))
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = stream;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    bitmap.Freeze();
                    this.img.Source = bitmap;
                }
