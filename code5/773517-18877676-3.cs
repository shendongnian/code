    public static class BitmapExtensions {
      public static Bitmap DoubleBitmap(this Bitmap bm){
         Bitmap bitmap = new Bitmap(bm.Width * 2, bm.Height);
         using(Graphics g = Graphics.FromImage(bitmap)){
           Rectangle rect = new Rectangle(Point.Empty, bm.Size);
           g.DrawImage(bm, rect);
           rect.Offset(bm.Width,0);
           g.DrawImage(bm, rect);
           return bitmap;
         }
      }      
      public static Bitmap AppendBitmap(this Bitmap bm, Bitmap rightBitmap){
        Bitmap bitmap = new Bitmap(bm.Width + rightBitmap.Width, Math.Max(bm.Height, rightBitmap.Height));
        using(Graphics g = Graphics.FromImage(bitmap)){
           Rectangle rect = new Rectangle(Point.Empty, bm.Size);
           g.DrawImage(bm, rect);
           rect = new Rectangle(new Point(bm.Width, 0), rightBitmap.Size);
           g.DrawImage(rightBitmap, rect);           
           return bitmap;
         }
      }
    }
    //Use it
    //Double the same image
    Bitmap doubledBitmap = yourBitmap.DoubleBitmap();
    //Append new image
    Bitmap appendedBitmap = yourBitmap.AppendBitmap(yourSecondBitmap);
