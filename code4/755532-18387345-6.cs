    public partial class MVVMDataGrid : Window
    {
        public MVVMDataGrid()
        {
            InitializeComponent();
            DataContext = Enumerable.Range(1, 5)
                                    .Select(x => new Job {Name = "Job" + x})
                                    .ToList();
        }
    }
