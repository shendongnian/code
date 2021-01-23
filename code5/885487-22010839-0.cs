    ObservableCollection<KeyValuePair<double, double>> cpuList = new ObservableCollection<KeyValuePair<double, double>>(); 
    public int counter = 0; 
    public MainWindow()
    {
        InitializeComponent();
        
        lineChart.DataContext = cpuList; 
        CPUEvent += showChart; 
    }
    private void showChart(object sender, CPUEventArgs args) //////
    {
        counter += 1;
        Dispatcher.BeginInvoke((Action)(() => cpuList.Add(new KeyValuePair<double, double>(counter, args.CurrentCPU)))); 
    }
