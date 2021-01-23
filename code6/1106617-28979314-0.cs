        public class ImageService : IImageService
        {
            public string GetImageData(string path)
            {
                if (File.Exists(path))
                {
                    return ConvertFile(path);
                }
                else
                    return string.Empty;
            }
    
            private string ConvertFile(string path)
            {
                using (Image image = Image.FromFile(path))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();
    
                        // Convert byte[] to Base64 String
                        string base64String = Convert.ToBase64String(imageBytes);
                        return base64String;
                    }
                }
            }        
        }
