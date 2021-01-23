    public partial class MainWindow : Window
    {
        private Rectangle rect;
        int count = 1;
        private DispatcherTimer timer = null;
        public MainWindow()
        {
            InitializeComponent();
            Rectangle movedRectangle = new Rectangle();
            movedRectangle.Width = 200;
            movedRectangle.Height = 50;
            movedRectangle.Fill = Brushes.Blue;
            movedRectangle.Opacity = 0.5;
            TranslateTransform translateTransform1 = new TranslateTransform(50, 20);
            movedRectangle.RenderTransform = translateTransform1;
            this.can.Children.Add(movedRectangle);
            this.rect = movedRectangle;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Tick += timer_Tick;
            timer.Start();
            timer.IsEnabled = true;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            count++;
            TranslateTransform translateTransform1 = new TranslateTransform(50 + count * 2, 20);
            Dispatcher.BeginInvoke(new Action<TranslateTransform>(delegate(TranslateTransform t1)
                {
                    rect.RenderTransform = t1;
                    this.can.UpdateLayout();
                }), System.Windows.Threading.DispatcherPriority.Render, translateTransform1);
        }
    }
