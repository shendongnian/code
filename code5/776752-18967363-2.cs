     int width,height;
        public Form1()
        {
            InitializeComponent();
            PictureBox pc = new PictureBox();
            pc.Dock = DockStyle.Fill;
            this.Controls.Add(pc);
            pc.Visible = false;
            width = pc.Width;
            height = pc.Height;
            pc.Dispose();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            
            using (Graphics g = this.CreateGraphics())
            {
                int border = 2;
                int startPos = 0;
                // offset used to correctly paint all the way to the right and bottom edges
                int offset = 1;
                Rectangle rect = new Rectangle(startPos, startPos, width,height);
                Pen pen = new Pen(Color.Red, border);
    
                // draw a border 
                g.DrawRectangle(pen, rect);
            }
            
        }
