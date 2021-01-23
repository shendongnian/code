     internal class PictureConverter : AxHost
     {
         private PictureConverter() : base(String.Empty) { }
         static public stdole.IPictureDisp ImageToPictureDisp(Image image)
         {
             return (stdole.IPictureDisp)GetIPictureDispFromPicture(image);
         }
         static public stdole.IPictureDisp IconToPictureDisp(Icon icon)
         {
              return ImageToPictureDisp(icon.ToBitmap());
          }
         static public Image PictureDispToImage(stdole.IPictureDisp picture)
         {
              return GetPictureFromIPicture(picture);
         }
      }
