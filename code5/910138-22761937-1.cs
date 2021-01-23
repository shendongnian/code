    public enum Resolutions { Wvga, Wxga, Hd };
    public class ScreenExtension
    {
        public static bool IsWvga
        {
            get
            {
                return Application.Current.Host.Content.ScaleFactor == 100;
            }
        }
        public static bool IsWxga
        {
            get
            {
                return Application.Current.Host.Content.ScaleFactor == 160;
            }
        }
        public static bool IsHd
        {
            get
            {
                return Application.Current.Host.Content.ScaleFactor == 150;
            }
        }
        public static Resolutions CurrentResolution
        {
            get
            {
                if (IsWvga) return Resolutions.Wvga;
                if (IsWxga) return Resolutions.Wxga;
                if (IsHd) return Resolutions.Hd;
                
                throw new InvalidOperationException("Unknown resolution");
            }
        }
    }
