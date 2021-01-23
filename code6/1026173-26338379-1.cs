    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            _myfavclass = new favclass();
            InitializeComponent();
            this.DataContext = this;
        }
        private readonly favclass _myfavclass;
        //we will use this property inside XAML code
        public favclass MyFavClass {
            get {
               return _myfavclass;
            }
        }
    }
