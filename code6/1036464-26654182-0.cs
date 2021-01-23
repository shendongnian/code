     private void writeColorImage(Object frame)
        {
            using (ColorFrame colorFrame = (ColorFrame)frame)
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(ToBitmap(colorFrame)));
                using (var filestream = new FileStream(filelocation + "image" + frameCount + ".jpg", FileMode.Create))
                    encoder.Save(filestream);
            }
        }
