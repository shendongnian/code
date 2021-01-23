    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
            this.BackColor = Color.Red;
            this.SizeChanged += MyUserControl_SizeChanged;
        }
        void MyUserControl_SizeChanged(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rc = this.ClientRectangle;
            gp.AddRectangle(rc);
            rc.Inflate(-4, -4);
            gp.AddRectangle(rc);
            this.Region = new Region(gp);
        }
    }
