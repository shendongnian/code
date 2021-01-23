    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.IO;
    namespace WpfApplication1
    {
      public partial class Window1 : Window
      {
        public Window1()
        {
          InitializeComponent();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
          short[] Buf = new short[64 * 64];
          BitmapSource bmpSrc = BitmapSource.Create(
            64, 64, 96, 96, PixelFormats.Gray16, null, Buf, 128);
          TransformedBitmap transformedBmp = new TransformedBitmap(bmpSrc, new RotateTransform(-90));
          PngBitmapEncoder enc = new PngBitmapEncoder();
          enc.Frames.Add(BitmapFrame.Create(transformedBmp));
          using (FileStream fs = new FileStream("D:\\Temp\\Test.png", FileMode.Create))
          {
            enc.Save(fs);
          }
        }
       }
       }    
