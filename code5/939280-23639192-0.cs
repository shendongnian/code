    public partial class MyUserControl : UserControl
    {
        private TabControl _tabControl;
    
        public MyUserControl()
        {
            InitializeComponent();
        }
    
        public void AssignTabControl(TabControl tabControl)
        {
            _tabControl = tabControl;
        }
    
        private void buttonNextTab_Click(object sender, EventArgs e)
        {
            _tabControl.SelectedIndex += 1;
        }
    }
