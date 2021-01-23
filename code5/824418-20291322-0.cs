    public partial class SomeUserControl : UserControl
    {
        public SomeUserControl()
        {
            InitializeComponent();
            this.pictureBox1.MouseMove += SomeUserControl_MouseMove;
            this.label1.MouseMove += SomeUserControl_MouseMove;
        }
        private void SomeUserControl_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
    }
