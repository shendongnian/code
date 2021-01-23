    using (var stream = new FileStream(path, FileMode.Open))
            {
                using (var image = Image.FromStream(stream))
                {
                    stream.Close();
                    var format = YourClass.GetImageFormat(image);
                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    image.Save(path, format);
                    image.Dispose();
                }
            }
