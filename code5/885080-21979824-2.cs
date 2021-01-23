    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SetContentType_Click(object sender, RoutedEventArgs e)
        {
            TestData test = this.DataContext as TestData;
            test.TypeContent = null;
        }
        private void GetAccessToTextBox_Click(object sender, RoutedEventArgs e)
        {
            TextBox MyTextBox = null;
            StackPanel panel = MainContentControl.Content as StackPanel;
            foreach (object child in panel.Children)
            {
               if (child is TextBox)
               {
                    MyTextBox = child as TextBox;
               }
            }
            if (MyTextBox != null) 
            {
                MyTextBox.Background = Brushes.Gainsboro;
                MyTextBox.Height = 100;
                MyTextBox.Text = "Got access to me!";
            }
        }
    }
    public class TestData : NotificationObject
    {
        private string _typeContent = "Init";
        public string TypeContent
        {
            get
            {
                return _typeContent;
            }
            set
            {
                _typeContent = value;
                NotifyPropertyChanged("TypeContent");   
            }
        }
    }
    public class NotificationObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
