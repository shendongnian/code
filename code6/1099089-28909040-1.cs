    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media.Imaging;
    namespace WpfApplication1
    {
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public MainWindow()
            {
                ZoomFactor = 8;
                ImageZoomSize = 200;
                InitializeComponent();
                BorderZoom.Visibility = Visibility.Hidden;
            }
            public double Xt { get; private set; }
            public double Yt { get; private set; }
            public double ZoomFactor { get; private set; }
            public int ImageZoomSize { get; private set; }
            public int ImageZoomSizeHalf { get { return ImageZoomSize/2; } }
            public Point CenterPoint { get { return new Point(ImageZoomSizeHalf, ImageZoomSizeHalf);} }
         
           
            private void FullImage_OnMouseDown(object sender, MouseButtonEventArgs e)
            {
                BorderZoom.Visibility = Visibility.Visible;
                FullImage_OnMouseMove(sender, e);
            }
            private void FullImage_OnMouseMove(object sender, MouseEventArgs e)
            {
                if (BorderZoom.Visibility == Visibility.Visible)
                {
                    BorderZoom.Visibility = Visibility.Visible;
                    var pos = e.GetPosition(FullImage);
                    Canvas.SetLeft(BorderZoom, pos.X - ImageZoomSizeHalf);
                    Canvas.SetTop(BorderZoom, pos.Y - ImageZoomSizeHalf);
                    var isrc = FullImage.Source as BitmapSource;
                    if(isrc == null) return;
                    var h = (double)isrc.PixelHeight;
                    var w = (double)isrc.PixelWidth;              
                    Xt = pos.X* (-ImageZoomSize/w) + ImageZoomSize/2.0;
                    Yt = pos.Y * (-ImageZoomSize / h) + ImageZoomSize / 2.0;
        
                    OnNotifyPropertyChanged("Xt");
                    OnNotifyPropertyChanged("Yt");
                }
            }
            private void FullImage_OnMouseUp(object sender, MouseButtonEventArgs e)
            {
                BorderZoom.Visibility = Visibility.Hidden;
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnNotifyPropertyChanged(string propName)
            {
                if(PropertyChanged!= null) PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
