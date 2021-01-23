     public partial class TestControl : UserControl
     {
        public TestControl()
        {
            InitializeComponent();
        }
        public TestControl(string name)
        {
            lblName.Content = name;
            InitializeComponent();
        }
     }
