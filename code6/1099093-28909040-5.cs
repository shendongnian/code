    using System.Windows.Media.Imaging;
    namespace WpfApplication1
    {
        public partial class MagifiyingTipCtrl : UserControl
        {
            public MagifiyingTipCtrl()
            {
                ZoomFactor = 8;
                ZoomWidth = 136;
                ZoomHeight = 128;
                InitializeComponent();
            }
            public static readonly DependencyProperty SourceImageProperty =
                DependencyProperty.Register("SourceImage", typeof (BitmapSource), typeof (MagifiyingTipCtrl));
            public static readonly DependencyProperty XtProperty =
                DependencyProperty.Register("Xt", typeof(double), typeof(MagifiyingTipCtrl));
            public static readonly DependencyProperty YtProperty =
                DependencyProperty.Register("Yt", typeof(double), typeof(MagifiyingTipCtrl));
            public BitmapSource SourceImage
            {
                get { return (BitmapSource)GetValue(SourceImageProperty); }
                set { SetValue(SourceImageProperty, value); }
            }
            public double Xt
            {
                get { return (double)GetValue(XtProperty); }
                set { SetValue(XtProperty, value); }
            }
            public double Yt
            {
                get { return (double)GetValue(YtProperty); }
                set { SetValue(YtProperty, value); }
            }
            public void SetPosition(Point pos)
            {
                if (SourceImage == null) return;
            
                var h = (double)SourceImage.PixelHeight;
                var w = (double)SourceImage.PixelWidth;
                Xt = pos.X * (-ZoomWidth / w) + ZoomWidth / 2.0;
                Yt = pos.Y * (-ZoomHeight / h) + ZoomHeight / 2.0;
            }
            public double ZoomFactor { get; private set; }
            public int ZoomWidth { get; private set; }
            public int ZoomHeight { get; private set; }
            public int ZoomWidthHalf { get { return ZoomWidth / 2; } }
            public int ZoomHeightHalf { get { return ZoomHeight / 2; } }
            public Point CenterPoint { get { return new Point(ZoomWidthHalf, ZoomHeightHalf); } }
        }
    }
