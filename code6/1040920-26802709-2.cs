     public partial class SampleWindow : Window  
     {
        private SampleViewModel _data;
        public SampleWindow()
        {
            _data = mainWindowViewmodel;
            InitializeComponent();
            this.DataContext = _data;
        }
     }  
