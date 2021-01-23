        GraphicsPath gp;
        int moldX = 10;
        int moldY = 10;
        
        public Form1()
        {
            InitializeComponent();
            gp = new GraphicsPath();  
        }
         
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPath(Brushes.Black, gp);
            // if you want the numbers outlined do e.Graphics.DrawPath
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            AddToPath();
            Invalidate();   
        }
        
        private void AddToPath()
        {
            using (Font useFont = new Font("Gotham Medium", 28, FontStyle.Bold))
            {
                Random rnd = new Random();
                string header2 = rnd.Next().ToString();
                int strsize = TextRenderer.MeasureText(header2, useFont).Height;
                StringFormat format = StringFormat.GenericDefault;
                gp.AddString(header2, useFont.FontFamily, 1, 28, new Point(moldX, moldY), format);
                
                moldX += 5;
                moldY += strsize;
            }
        }
