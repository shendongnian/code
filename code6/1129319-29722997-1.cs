     public partial class Foreground_Form : Form
    {
        public Foreground_Form()
        {
            InitializeComponent();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            TransparencyKey = this.BackColor;
            StartPosition = FormStartPosition.CenterScreen;
            this.Paint += Foreground_Form_Paint;
        }
        void Foreground_Form_Paint(object sender, PaintEventArgs e)
        {
            //this is for the Stroke
            e.Graphics.DrawRectangle(Pens.White, new Rectangle(0, 0, Width - 1, Height - 1));
        }
    }
