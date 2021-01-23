    public partial class Form1 : Form
    {
        private Pen pen;
        private Graphics paper;
        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Blue, 5);
            paper = this.CreateGraphics();
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(Form1_MouseMove);
        }
        private void Form1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
                paper.Clear(this.BackColor);
                paper.DrawRectangle(pen, e.X + 10, this.ClientRectangle.Height - 20, 50, 10);
        }
    }
