    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            BackColor = Color.Lime;
            label1.ForeColor = Color.White;
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            BackColor = Color.White;
            label1.ForeColor = Color.Black;
            base.OnMouseLeave(e);
        }
    }
