    private string toB64img(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, ImageFormat.Png);   
                byte[] imageBytes = ms.ToArray();
                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                GC.Collect();                       <======
                GC.WaitForPendingFinalizers();      <======
                GC.Collect();                       <======
                return base64String;
            }
        }
``
