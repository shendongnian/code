    private Bitmap GetImageBitmapFromUrl(string url)
    {
         Bitmap imageBitmap = null;
    
         using (var webClient = new WebClient())
         {
              var imageBytes = webClient.DownloadData(url);
              if (imageBytes != null && imageBytes.Length > 0)
              {
                   imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
              }
         }
    
         return imageBitmap;
    }
    
    var imageBitmap = GetImageBitmapFromUrl("http://xamarin.com/resources/design/home/devices.png");
    imagen.SetImageBitmap(imageBitmap);
