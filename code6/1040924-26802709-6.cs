     public partial class SampleWindow : Window  
     {
        private SampleViewModel _data;
        public SampleWindow()
        {
            _data = new SampleViewModel();
            InitializeComponent();
            this.DataContext = _data;
        }
     }  
