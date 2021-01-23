    class MyResourseConverter : IValueConverter
    {
      private static readonly IImageManager _imageManager = 
        new CachedImageManager(new SystemImageManager());
    
      public MyResourceConverter()
      {
         _imageManager = App.GetInstance<IImageManager>();
      }
      
      //... IValueConverter Properties
      //... That uses the _imageManger
    }
