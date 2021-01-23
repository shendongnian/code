    using System;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;
    using System.Windows.Threading;
    
    namespace WpfApplication1
    {
        public partial class Animation : UserControl
        {
            private int index = 1;
            private DispatcherTimer timer;
    
            public BitmapImage _Image1 { get; set; }
            public BitmapImage _Image2 { get; set; }
    
            public Animation()
            {
                InitializeComponent();
            }
    
            public void Initiate()
            {
                if (_Image1 != null || _Image2 != null)
                {
                    image.Source = _Image1;
    
                    this.timer = new DispatcherTimer(DispatcherPriority.Render);
                    this.timer.Interval = TimeSpan.FromMilliseconds(100.0);
                    this.timer.Tick += new EventHandler(this.updateImage);
                    this.timer.Start();
                }
            }
    
            private void updateImage(object sender, EventArgs e)
            {
                if (index == 1)
                {
                    image.Source = _Image2;
                    index++;
                }
                else
                {
                    image.Source = _Image1;
                    index--;
                }
            }
        }
    }
