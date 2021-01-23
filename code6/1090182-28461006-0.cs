     public void CreateMakerNoteJpgImage(byte[] makerNoteArray, string path)
            {
                BitmapPalette myPalette = BitmapPalettes.WebPalette;
    
                // Creates a new empty image with the pre-defined palette
                BitmapSource image = BitmapSource.Create(
                    Width,
                    Height,
                    96,
                    96,
                    PixelFormats.Bgr24,
                    myPalette,
                    _channels[0].Data,
                    Width * 3);
    
                FileStream stream = new FileStream(path, FileMode.Create);
                
                BitmapMetadata metadata = new BitmapMetadata("jpg");
                //adding makernote data into EXIF of the jpeg image
                metadata.SetQuery("/app1/ifd/exif:{uint=37500}", makerNoteArray);
                
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.FlipHorizontal = false;
                encoder.FlipVertical = false;
                encoder.QualityLevel = 30;
                BitmapFrame frame = BitmapFrame.Create(image, null, metadata, null);
                encoder.Frames.Add(frame);
                encoder.Save(stream);
            }
