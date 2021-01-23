    public sealed partial class GrandFatherView
    {
        public GrandFatherView()
        {
            InitializeComponent();
            var fatherView = new FatherView
                             {
                                 DataContext = new FatherViewModel
                                               {
                                                   SonViewModel = new SonViewModel()
                                               }
                             };
            MainGrid.Children.Add(fatherView);
        }
    }
