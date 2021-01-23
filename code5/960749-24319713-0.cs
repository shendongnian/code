    public partial class MainWindow : Window
    {
        ObservableCollection<ChartData> chartData;
        ChartData objChartData;
        Thread MyThread;
        public MainWindow()
        {
            InitializeComponent();
            chartData = new ObservableCollection<ChartData>();
            objChartData = new ChartData() { Name = DateTime.Now.Second.ToString(), Value = 0.0 };
            chartData.Add(objChartData);
            simChart.DataContext = chartData;
            MyThread = new Thread(new ThreadStart(StartChartDataSimulation));
        }
        void MainWindow_DataChanged()
        {
            throw new NotImplementedException();
        }
        public void StartChartDataSimulation()
        {
            while (true)
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    chartData.Add(new ChartData() { Name = DateTime.Now.Second.ToString(), Value = new Random().NextDouble() });
                }));
                //objChartData.Name = DateTime.Now.Second.ToString();
                //objChartData.Value = new Random().NextDouble();
                Thread.Sleep(500);
            }
        }
        private void btnStartStop_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btnStartStop.Content == "Start Simulation")
            {
                if (MyThread.ThreadState == ThreadState.Unstarted)
                {
                    MyThread.Start();
                }
                else if (MyThread.ThreadState == ThreadState.Suspended)
                {
                    MyThread.Resume();
                }
                btnStartStop.Content = "Stop Simulation";
            }
            else
            {
                MyThread.Suspend();
                btnStartStop.Content = "Start Simulation";
            }
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            MyThread.Suspend();
            Application.Current.Shutdown();
        }
        
    }
    public class ChartData : INotifyPropertyChanged
    {
        string _Name;
        double _Value;
        #region properties
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
        public double Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
                OnPropertyChanged("Value");
            }
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
    }
