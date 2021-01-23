    public partial class MainWindow : Window
    {
        private readonly Dal _data = new Dal();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        
            _data.GetAgentStatesAsync(); // Fire Task away, no time to wait!!1
        }
        public Dal Data { get { return _data; } }  
    }
    public class EstadosAgente
    {
        public string Estado { get; set; }
    }
    public class Dal : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Task GetAgentStatesAsync()
        {
            return Task.Run(() =>
                {
                    Thread.Sleep(1000); // I'm a long running operation...
                    var estados = new List<EstadosAgente>
                        {
                            new EstadosAgente { Estado = "Estado 1" },
                            new EstadosAgente { Estado = "Estado 2" }
                        };
                    EstadosPausa = new ObservableCollection<EstadosAgente>(estados);
                    OnPropertyChanged("EstadosPausa");
                });
        }
        public ObservableCollection<EstadosAgente> EstadosPausa { get; private set; }
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged; // <- always assign to local variable!
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
