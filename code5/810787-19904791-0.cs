       public enum Resolutions { WVGA, WXGA, HD720p, HD };
        private static bool IsWvga
        {
            get
            {
                return App.Current.Host.Content.ScaleFactor == 100;
            }
        }
        private static bool IsWxga
        {
            get
            {
                return App.Current.Host.Content.ScaleFactor == 160;
            }
        }
        private static bool Is720p
        {
            get
            {
                return App.Current.Host.Content.ScaleFactor == 150;
            }
        }
        private static bool IsHD
        {
           get 
          { 
             return App.Current.Host.Content.ScaleFactor == 150; 
          }
        }
