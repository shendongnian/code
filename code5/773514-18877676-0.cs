    public static class BitmapExtensions {
      public static Bitmap DoubleBitmap(this Bitmap bm){
         Bitmap bitmap = new Bitmap(bm.Width * 2, bm.Height);
         using(Graphics g = Graphics.FromImage(bitmap)){
           Rectangle rect = new Rectangle(0,0,bm.Width, bm.Height);
           g.DrawImage(bm, rect);
           g.TranslateTransform(bm.Width,0);
           g.DrawImage(bm, rect);
           return bitmap;
         }
      }      
    }
    //Use it
    Bitmap doubledBitmap = yourBitmap.DoubleBitmap();
