        public MainWindow()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }
        public event EventHandler Tick;        
                       
        private DispatcherTimer tmr = new DispatcherTimer(); //Timer for Slide Show.
        private DispatcherTimer tmrPse = new DispatcherTimer(); //Timer for click events.
        private List<string> images = new List<string>();        
        public int imageIndex =-1; //Determines which slide to show.        
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            tmr.Interval = new TimeSpan(0, 0, 2);
            tmr.Tick += new EventHandler(tmr_Tick);
            
            tmrPse.Interval = new TimeSpan(0, 0, 5);
            tmrPse.Tick += new EventHandler(tmrPse_Tick);
            LoadImages();
            tmr.Start();
        }
        private void LoadImages()
        {
            // list the files (includede in the XAP file) here
            images.Add("/Images/AYDAYC.jpg"); //imageIndex = 0
            images.Add("/Images/CNNBert.jpg"); //imageIndex = 1
            images.Add("/Images/rwbjets.jpg"); //imageIndex = 2
            images.Add("/Images/worldmap.jpg"); //imageIndex = 3
        }
        private void ShowNextImage()
        {
            imageIndex = (imageIndex + 1) % images.Count;
            var bi = new BitmapImage(new Uri(images[imageIndex], UriKind.Relative));
            myImage.Source = bi;
        }
        private void ShowLastImage()
        {
            imageIndex = (imageIndex - 1);
            if (imageIndex < 0)
            {
                imageIndex = 3;
            }
            var bi = new BitmapImage(new Uri(images[imageIndex], UriKind.Relative));
            myImage.Source = bi;
        }
        private void BoxColor()
        {
            if (imageIndex == 3)
            {
                LftRct.Fill = new SolidColorBrush(Colors.Green);
                MidRct.Fill = new SolidColorBrush(Colors.SpringGreen);
                RtRct.Fill = new SolidColorBrush(Colors.PaleGreen);
            }
            else if (imageIndex == 2)
            {
                LftRct.Fill = new SolidColorBrush(Colors.Blue);
                MidRct.Fill = new SolidColorBrush(Colors.RoyalBlue);
                RtRct.Fill = new SolidColorBrush(Colors.SkyBlue);
            }
            else if (imageIndex == 1)
            {
                LftRct.Fill = new SolidColorBrush(Colors.White);
                MidRct.Fill = new SolidColorBrush(Colors.Silver);
                RtRct.Fill = new SolidColorBrush(Colors.SlateGray);
            }
            else
            {
                LftRct.Fill = new SolidColorBrush(Colors.Red);
                MidRct.Fill = new SolidColorBrush(Colors.Tomato);
                RtRct.Fill = new SolidColorBrush(Colors.Pink);
            }            
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            ShowNextImage();
            BoxColor();
        }
        void tmrPse_Tick(object sender, EventArgs e)
        {                      
            tmr.Start();
        }
        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            tmr.Stop();
            tmrPse.Start();
            ShowLastImage();
            BoxColor();                      
        }
        private void btnPause_Click(object sender, RoutedEventArgs e)
        {            
            tmr.Stop();
            tmrPse.Start();                       
        }       
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            tmr.Stop();
            tmrPse.Start();
            ShowNextImage();
            BoxColor();
         }       
