    public string ImageToBase64(Image image)
        {
            using (MemoryStream m = new MemoryStream())
            {
                image.Save(m, image.RawFormat);
                byte[] imageBytes = m.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                string a = base64String.Replace('/', '_').Replace('+', '-').Replace('=', ',');
                base64String = a;
                return base64String;
            }
        }
    
        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            string a = base64String.Replace('_', '/').Replace('-', '+').Replace(',', '=');
            base64String = a;
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);
    
            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
          
