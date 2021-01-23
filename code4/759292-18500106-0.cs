    public Form1()
        {
            InitializeComponent();
            pictureBox1.MouseDown += new MouseEventHandler(Form1_MouseDown);
            pictureBox1.MouseMove += new MouseEventHandler(Form1_MouseMove);
            pictureBox1.MouseUp += new MouseEventHandler(Form1_MouseUp);
        }
        void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isHolding = false;
        }
        void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isHolding)
            {
                int diffX = this.Width - pictureBox1.Left;
                int diffY = this.Height - pictureBox1.Top;
                pictureBox1.Left += e.X - curX;
                pictureBox1.Top += e.Y - curY;
                this.Width = pictureBox1.Left + diffX;
                this.Height = pictureBox1.Top + diffY;                
            }
        }
        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isHolding = true;
            curX = e.X;
            curY = e.Y;
        }
        int curX = 0, curY = 0;
        bool isHolding = false;
    
