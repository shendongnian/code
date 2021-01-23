    public Show()
    {
       InitializeComponent();
       App.MainViewModel.LoadData();
       this.DataContext = App.MainViewModel;
    }
