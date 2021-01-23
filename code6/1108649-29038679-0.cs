        public MainWindow()
        {
            InitializeComponent();
            var thread = new Thread(CreateScreenshot);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        private void CreateScreenshot()
        {
            Canvas c = new Canvas { Width = 100, Height = 100 };
            c.Children.Add(new Rectangle { Height = 100, Width = 100, Fill = new SolidColorBrush(Colors.Red) });
            var bitmap = new RenderTargetBitmap((int)c.Width, (int)c.Height, 120, 120, PixelFormats.Default);
            c.Measure(new Size((int)c.Width, (int)c.Height));
            c.Arrange(new Rect(new Size((int)c.ActualWidth, (int)c.ActualHeight)));
            bitmap.Render(c);
            var png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(bitmap));
            using (Stream stm = File.Create("c:\\temp\\test.png"))
            {
                png.Save(stm);
            }
        }
