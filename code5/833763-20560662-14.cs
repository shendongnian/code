    public sealed partial class GrandFatherView
    {
        public GrandFatherView()
        {
            InitializeComponent();
            var fatherView = new FatherView { DataContext = new FatherViewModel() };
            MainGrid.Children.Add(fatherView);
        }
    }
