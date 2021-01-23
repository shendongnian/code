        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();       
        }
    }
    public class ViewModel
    {
        private ObservableCollection<Sample> _samples = new ObservableCollection<Sample>()
        {
            new Sample()
            {
                Name = "Sample1",
                ExperimentResult = new Measurement()
                { MeasuredValue = 100.00, xPosition = 1, yPosition = 0}
            },
            new Sample()
            {
                Name = "Sample2",
                ExperimentResult = new Measurement()
                {
                    MeasuredValue = 50.00, xPosition = 2, yPosition = 3}
            }
        };
        public ObservableCollection<Sample> Samples
        {
            get
            {
                return _samples;
            }
        }
    }
    public class Sample : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }
        private Measurement experimentResult;
        public Measurement ExperimentResult
        {
            get
            {
                return experimentResult;
            }
            set
            {
                experimentResult = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ExperimentResult"));
            }
        }
    }
    public class Measurement
    {
        public double xPosition { get; set; }
        public double yPosition { get; set; }
        public double MeasuredValue { get; set; }
    }
