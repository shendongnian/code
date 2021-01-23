    public static class BitmapExtensions {
      public static Bitmap DoubleBitmap(this Bitmap bm){
         Bitmap bitmap = new Bitmap(bm.Width * 2, bm.Height);
         using(Graphics g = Graphics.FromImage(bitmap)){
           g.DrawImage(bm, Point.Empty);
           g.DrawImage(bm, new Point(bm.Width,0));
           return bitmap;
         }
      }      
      public static Bitmap AppendBitmap(this Bitmap bm, Bitmap rightBitmap){
        Bitmap bitmap = new Bitmap(bm.Width + rightBitmap.Width, Math.Max(bm.Height, rightBitmap.Height));
        using(Graphics g = Graphics.FromImage(bitmap)){
           g.DrawImage(bm, Point.Empty);           
           g.DrawImage(rightBitmap, new Point(bm.Width, 0));
           return bitmap;
         }
      }
    }
    //Use it
    //Double the same image
    Bitmap doubledBitmap = yourBitmap.DoubleBitmap();
    //Append new image
    Bitmap appendedBitmap = yourBitmap.AppendBitmap(yourSecondBitmap);
