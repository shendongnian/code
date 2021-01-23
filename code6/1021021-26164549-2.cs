    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        CancellationTokenSource cTS;
        CancellationToken cT;
        private String _textBoxValue;
        public String TextBoxValue
        {
            get { return _textBoxValue; }
            set 
            {
                _textBoxValue = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("TextBoxValue"));
                }
                if (_textBoxValue.Contains("enough"))
                {
                    cTS.Cancel();
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            cTS = new CancellationTokenSource();
            cT = cTS.Token;
            Task.Factory.StartNew(ChangeTextBoxValue, cT);
        }
        public void ChangeTextBoxValue()
        {
            while (true)
            {
                Random rnd = new Random(DateTime.Now.Millisecond);
                TextBoxValue = (rnd.NextDouble() * 1000.0).ToString();
                Thread.Sleep(10000);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
