    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Computations = new ObservableCollection<Computation>();
            Computations.Add(new Computation());
            Computations.Add(new Computation());
            Computations.Add(new Computation());
            DataContext = this;
            Computations[1].IsCompleted = true;
        }
        public ObservableCollection<Computation> Computations { get; set; }
    }
