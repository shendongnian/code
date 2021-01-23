     public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            ShowInTaskbar = false;
            this.Opacity = 0.8;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 0, 0)), this.ClientRectangle);
        }
    }
