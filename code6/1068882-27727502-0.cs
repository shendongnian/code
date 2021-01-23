    public static class DataClassExtensions
    {
         public static BitmapImage GetImage(this DataClass data)
         {
             if(data == null || data.ImageArray == null) return null;
             using (var ms = new System.IO.MemoryStream(data.ImageArray))
             {
                  Bitmap image = (Bitmap)Image.FromStream(ms);
                  return image;
             }
         }
    }
    public class DataClass
    {
         public byte[] ImageArray { get; set; }
    }
