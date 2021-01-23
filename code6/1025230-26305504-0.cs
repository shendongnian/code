    using System;
    using System.Windows;
    using System.Windows.Media.Imaging;
    using Hjg.Pngcs;
    
    namespace WpfApplication3
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                Loaded += MainWindow_Loaded;
            }
    
            private void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                int width = 14043;
                int height = 9933;
                int stride;
                byte[] bytes = GetBitmap(width, height, out stride);
                var imageInfo = new ImageInfo(width, height, 1, false, true, false);
    
                PngWriter pngWriter = FileHelper.CreatePngWriter("test.png", imageInfo, true);
                var row = new byte[stride];
                for (int y = 0; y < height; y++)
                {
                    int offset = y*stride;
                    int count = stride;
                    Array.Copy(bytes, offset, row, 0, count);
                    pngWriter.WriteRowByte(row, y);
                }
                pngWriter.End();
    
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri("test.png", UriKind.Relative);
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                bitmapImage.EndInit();
                Image1.Source = bitmapImage;
            }
    
            private byte[] GetBitmap(int width, int height, out int stride)
            {
                stride = (int) Math.Ceiling((double) width/8);
                var pixels = new byte[stride*height];
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        var color = (byte) (y < height/2 ? 0 : 1);
                        int byteOffset = y*stride + x/8;
                        int bitOffset = x%8;
                        byte b = pixels[byteOffset];
                        b |= (byte) (color << (7 - bitOffset));
                        pixels[byteOffset] = b;
                    }
                }
    
                return pixels;
            }
        }
    }
