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
    
            public BitmapImage Image1 { get; set; }
            public BitmapImage Image2 { get; set; }
    
            public Animation()
            {
                InitializeComponent();
            }
    
            public void Initiate()
            {
                if (Image1 != null && Image2 != null)
                {
                    image.Source = Image1;
    
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
                    image.Source = Image2;
                    index++;
                }
                else
                {
                    image.Source = Image1;
                    index--;
                }
            }
        }
    }
