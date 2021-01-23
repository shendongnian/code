    public partial class MainWindow : Window
    {
        protected ObservableCollection<MyPanel> texts = new ObservableCollection<MyPanel>();
        public MainWindow()
        {
            InitializeComponent();
            texts.Add(new MyPanel() { Text = "Test 1" });
            texts.Add(new MyPanel() { Text = "Test 2" });
            lstItems.ItemsSource = texts;
        }
    }
    public class MyPanel : INotifyPropertyChanged
    {
        private string _id;
        private string _text;
        private double _fontSize = 10;
        public string Id
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Text
        {
            get { return _text; }
            set
            {
                if (value != _text)
                {
                    _text = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double FontSize
        {
            get { return _fontSize; }
            set
            {
                if (value != _fontSize)
                {
                    _fontSize = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
