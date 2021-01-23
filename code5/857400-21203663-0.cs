        static void Main(string[] args)
        {
            //choose my pictures/temp/file.jpg
            string target = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "temp", "file.jpg");
            //encode "test.bmp" to "my pictures/temp/file.jpg"
            EncodeToJPEG("test.bmp", target, 25);
        }
        public static void EncodeToJPEG(string sourceBitmap, string targetfile, long quality)
        {
            if(sourceBitmap == null)
                throw new ArgumentException("sourceBitmap");
            if(File.Exists(targetfile))
                throw new InvalidOperationException("target file already exists");
            var jpegCodec = ImageCodecInfo.GetImageEncoders().FirstOrDefault(x => x.MimeType == "image/jpeg");
            if (jpegCodec == null)
                throw new NotSupportedException();
            var jpegParams = new EncoderParameters(1);
            jpegParams.Param[0] = new EncoderParameter(Encoder.Quality, quality);
            var bitmap = new Bitmap(sourceBitmap);
            var dir = Path.GetDirectoryName(targetfile);
            if (dir != null && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            
            bitmap.Save(targetfile, jpegCodec, jpegParams);
        }
