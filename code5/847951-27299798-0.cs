    public static class ImageProcessing
    {
         public static Bitmap Process(Bitmap image, IFilter filter)
         {
             return filter.Apply(image);
         }
         public static Bitmap Process(string path, IFilter filter)
         {
             var image = (Bitmap)Image.FromFile(path);
             return filter.Apply(image);
         }
         public static Bitmap Process(string path, IEnumerable<IFilter> filters)
         {
             var image = (Bitmap)Image.FromFile(path);
             foreach (var filter in filters)
             {
                 Bitmap tempImage = filter.Apply(image);
                 image.Dispose();
                 image = tempImage;
             }
             return image;
         }
    }
