    public class Waiter : INotifyPropertyChanged
    {
        public async Task InitialLoad()
        {
            await Task.Delay(5000);
            this.Value = "Loaded";
        }
        public Waiter()
        {
            this.Value = "Loading data";
            InitialLoad();
        }
        private String _Value;
        public String Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                if (value == this._Value)
                    return;
                this._Value = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Value"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new Waiter();          
        }
