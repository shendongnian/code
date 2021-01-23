    internal class Program
    {
        public static BitmapSource GetResourceImage(string resourcePath, int decodePixelWidth = 0,
            int decodePixelHeight = 0)
        {
            var image = new BitmapImage();
            var moduleName = Assembly.GetExecutingAssembly().GetName().Name;
            var resourceLocation = string.Format("pack://application:,,,/{0};component/Resources/{1}", moduleName, resourcePath);
            image.BeginInit();
            image.UriSource = new Uri(resourceLocation);
            image.DecodePixelWidth = decodePixelWidth;
            image.DecodePixelHeight = decodePixelHeight;
            image.EndInit();
            image.Freeze();
            return image;
        }
        private static void Main()
        {
            new Application();  // register pack uri scheme
            //GetResourceImage("Z40100.png");
            //GetResourceImage("Z40100.bmp");
            //GetResourceImage("Z40100_256color.bmp");
            //GetResourceImage("Z40100_24bit.bmp");
            
            // Uncomment the following line to fix the crash (or any of the two lines above)
            //GetResourceImage("Z40100_24bit.bmp", 50, 50);
            //GetResourceImage("Z40100_256color.bmp", 50, 50);
            GetResourceImage("Z40100.bmp", 50, 50);
            // GetResourceImage("Z40100.png", 50, 50);
        }
    }
