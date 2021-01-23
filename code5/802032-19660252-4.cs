    public class Form1:Form
    {
        PictureBox pb;
        bool drawLines = false;
        public Form1()
        {
            InitializeComponent();
            pb = new PictureBox();
            pb.Size = new Size(100,100);
            pb.Location = new Point(0,0);
            pb.Paint+=new PaintEventHandler(pb_Paint);
            this.Controls.Add(pb);
        }
        private void pb_Paint(object sender, PaintEventArgs e)
        {
            if(drawLines)
            {
                Pen pen1 = new Pen(Color.Red);
                for (int i = 0; i < pb.Height; i+=2)
                {
                   e.Graphic.DrawLine(pen1, pb.Width, 0, 0, pb.Height);
                }
            }
        }
        public void Zimet()
        {
            drawLines = true; //however this may look redundant, it is still OP's code
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Zimet();
        }
