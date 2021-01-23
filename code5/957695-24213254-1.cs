    using System;
    using System.IO;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.UI;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media.Imaging;
    
    namespace App44
    {
        public sealed partial class MainPage : Page
        {
            private RenderTargetBitmap rtb;
    
            public MainPage()
            {
                this.InitializeComponent();
            }
    
            private async void SourceGrid_OnSizeChanged(object sender, SizeChangedEventArgs e)
            {
                this.rtb = new RenderTargetBitmap();
                await this.rtb.RenderAsync(this.SourceGrid);
                this.TargetImage.Source = this.rtb;
            }
    
            private async void TargetImage_OnPointerMoved(object sender, PointerRoutedEventArgs e)
            {
                var pixels = await this.rtb.GetPixelsAsync();
                var stream = pixels.AsStream();
                stream.Seek(0, SeekOrigin.Begin);
                var point = e.GetCurrentPoint(this.TargetImage);
                stream.Seek((long)(point.Position.Y) * this.rtb.PixelWidth * 4 + (long)(point.Position.X) * 4, SeekOrigin.Begin);
                byte b = (byte)stream.ReadByte();
                byte g = (byte)stream.ReadByte();
                byte r = (byte)stream.ReadByte();
                byte a = (byte)stream.ReadByte();
                //var color = Color.FromArgb(a, r, g, b);
                this.ResultTextBlock.Text = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}, is transparent: {4}", a, r, g, b, a == 0);            
            }
        }
    }
