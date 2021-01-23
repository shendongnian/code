     public partial class MainWindow : Window
    {
        private trainingWindow _trainingWindow;   
        public MainWindow()
        {
            InitializeComponent();
        }
        private void buttonGoTraining_Click(object sender, RoutedEventArgs e)
        {
            if (_trainingWindow== null)
            {
             _trainingWindow=  new trainingWindow(this);   
            }
             
            this.Visibility = Visibility.Hidden;  
            _trainingWindow.Show();
            _trainingWindow.Visibility  = Visibility.Visible;
            this.Visibility = Visibility.Hidden; 
        }
    }
