        public MainWindow()
        {
            InitializeComponent();
            first1.ButtonAction = Button1;
            first2.ButtonAction = Button2;
            first3.ButtonAction = Button3;
        }
        private void Button3(object sender, RoutedEventArgs e) { MessageBox.Show("Pressed 3"); }
        private void Button2(object sender, RoutedEventArgs e) { MessageBox.Show("Pressed 2"); }
        private void Button1(object sender, RoutedEventArgs e) { MessageBox.Show("Pressed 1"); }
