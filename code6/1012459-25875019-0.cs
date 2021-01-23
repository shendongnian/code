    public int sceneNumber=1;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void choose()
        {
            switch (sceneNumber)
            {
                case 1:
                    resetPict();
                    drawOne();
                    sceneNumber++;
                    break;
                case 2:
                    resetPict();
                    drawTwo();
                    sceneNumber = 1;
                    break;
               
            }
        }
           
        private void resetPict()
        {
            pictureBox1.BackColor= Color.Black;
        }
        private void drawOne()
        {
            Graphics gr = pictureBox1.CreateGraphics();          
            gr.FillRectangle(Brushes.Red, 30, 30, 150, 100);
        }
        private void drawTwo()
        {
            Graphics gr = pictureBox1.CreateGraphics();            
            gr.FillRectangle(Brushes.Blue, 30, 30, 150, 100);
        } 
        private void timer1_Tick(object sender, EventArgs e)
        {
            choose();
        }
    }
