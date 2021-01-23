    public partial class DemoUserControl : UserControl, IWorkSpaceViewControl
    {
        private bool canSave;
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
        public bool CanSave
        {
            get { return canSave; }
        }
        private void btnChangeCanSave_Click(object sender, RoutedEventArgs e)
        {
            canSave = !canSave;
        }
        public void Save()
        {
            Debug.WriteLine("DemoUserControl Save() executed");
        }
    }
