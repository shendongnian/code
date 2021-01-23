    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Components.Add(new Object());
            Components.Add(new Object());
        }
        private ObservableCollection<Object> components;
        public ObservableCollection<Object> Components
        {
            get
            {
                if (components == null)
                    components = new ObservableCollection<Object>();
                return components;
            }
        }
    }
