    private Random random = new Random();
    public List<double> Data { get; set; }
    public MainWindow()
    {
      InitializeComponent();
      var temp = new List<double>();
      for (int i = 0; i < 100; i++)
      {
        temp.Add(random.NextDouble() * 100);
      }
      Data = new List<double>(temp);
      RaisePropertyChanged("Data");
      Timer timer = new Timer(1);
      timer.Elapsed += (sender, args) =>
      {
        UpdateData();
      };
      timer.Start();
    }
    private void UpdateData()
    {
      var data = Data.ToArray();
      ShiftLeft(data, 1);
      var value = random.NextDouble() * 100;
      data[99] = value;
      Data = new List<double>(data); 
      RaisePropertyChanged("Data");
    }
    public void ShiftLeft<T>(T[] array, int shifts)
    {
      Array.Copy(array, shifts, array, 0, array.Length - shifts);
      Array.Clear(array, array.Length - shifts, shifts);
    }
    private void RaisePropertyChanged(string property)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(property));
    }
    public event PropertyChangedEventHandler PropertyChanged;
