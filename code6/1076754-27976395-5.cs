    public GenerateReportView()
    {
       InitializeComponent();
      //Some operations
      var generateReportViewModel  = new GenerateReportViewModel();
     this.DataContext = generateReportViewModel;
    }
