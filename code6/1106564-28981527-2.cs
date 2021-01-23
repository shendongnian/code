    public partial class DemoUserControl : UserControl, IWorkSpaceViewControl
    {
        public DemoUserControl()
        {
            InitializeComponent();
        }
        public void GetSelectedEntry()
        {
            // Your implementation
        }
        public void Refresh()
        {
            // Your Implementation
            Debug.WriteLine("DemoUserControl Refresh() executed");
        }
    }
