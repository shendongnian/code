    button1  = FindViewById(Resource.Id.RoundedRect);
    var imageBitmap = GetImageBitmapFromUrl("http://xamarin.com/resources/design/home/test.png");
    button1.SetImageBitmap(imageBitmap);
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
