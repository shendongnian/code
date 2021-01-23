    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Opacity = .5;
            this.TopMost = true;
            this.BackColor = Color.Yellow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            // Makes the form circular:
            System.Drawing.Drawing2D.GraphicsPath GP = new System.Drawing.Drawing2D.GraphicsPath();
            GP.AddEllipse(this.ClientRectangle);
            this.Region = new Region(GP);
        }
        const int WS_EX_TRANSPARENT = 0x20;
        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;
                return cp;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Point pt = Cursor.Position;
            pt.Offset(-1 * this.Width / 2, -1 * this.Height / 2);
            this.Location = pt;
        }
    }
