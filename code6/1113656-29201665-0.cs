        public MainWindow()
        {
            InitializeComponent();
            MouseUp += MainWindow_MouseUp; //add eventhandler vor click event
        }
        void MainWindow_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var img = new Image(); //create new instance of image
            img.Width = 100; //set some size properties
            img.Height = 100;
            img.Source = somesource;//set source
            MainGrid.Children.Add(img); //add it as a child to some conteiner element, like grid. 
        }
