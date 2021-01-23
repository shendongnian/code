    public partial class MainWindow : Window
    {
        public MyDictionary<string, string> Dic
        {
            get;
            set;
        }
        public MainWindow()
        {
            InitializeComponent();
            this.Dic = new MyDictionary<string, string>();
            this.DataContext = this;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Dic["0"] = new Random().Next().ToString();
        }
    }
    public class MyDictionary<TKey, TValue> : Dictionary<TKey, TValue>, INotifyPropertyChanged
    {
        public TValue this[TKey index]
        {
            get
            {
                return base[index];
            }
            set
            {
                base[index] = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(Binding.IndexerName));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
