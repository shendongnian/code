    public Form2()
        {
            InitializeComponent();
            //hide the boder of form
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = Color.White;
            //set the TransparencyKey the same as the back color
            this.TransparencyKey = this.BackColor;
        }
    protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush redpen = new SolidBrush(Color.Red);
            Font font = new Font("Arial", 16);
            PointF point = new PointF(400, 150);
            Graphics g = e.Graphics;
            string state = "running";
            g.DrawString(state, font, redpen, point);
            string amountOfTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", 1, 2, 3, 11111 / 10);
            PointF point2 = new PointF(500, 150);
            g.DrawString(amountOfTime, font, redpen, point2);
            //base.OnPaint(e);
        }
