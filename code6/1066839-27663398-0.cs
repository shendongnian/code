    public partial class myUserControl : UserControl
    {
        MainForm myMainForm;
    
        public myUserControl(MainForm mainForm)
        {
            InitializeComponent();
            myMainForm = mainForm;
        }
    
        private void Button1_MouseClick(object sender, MouseEventArgs e)
        {
            myMainForm.PanelBody.Controls.Add(new myUserControl2());
        }
    }
