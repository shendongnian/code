         class ImageStore
         {
             private static ImageStore current = new ImageStore();
             public static ImageStore Current
             {
                 get { return current; }
             }
         public BitmapImage Image { get; set; } 
         }
