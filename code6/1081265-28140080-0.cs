        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GridCreate();
            pictureBox1.Paint += pictureBox1_Paint;
        }
        private void GridCreate()
        {
            Rectangle[,] block = new Rectangle[16, 16];
            for (int i = 0; i < block.GetLength(1); i++) // this is the 2nd dimension, so GetLength(1)
            {
                for (int n = 0; n < block.GetLength(0); n++) // this is the 1st dimension, so GetLength(0)
                {
                    block[n, i] = new Rectangle(i * blockSize, n * blockSize, 20, 20);
                }
            }
            data.block = block;
        }
        void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; // use the SUPPLIED graphics, NOT CreateGraphis()!
            for (int i = 0; i < data.block.GetLength(1); i++) // this is the 2nd dimension, so GetLength(1)
            {
                for (int n = 0; n < data.block.GetLength(0); n++) // this is the 1st dimension, so GetLength(0)
                {
                    g.FillRectangle(Brushes.Black, data.block[n, i]);
                }
            }
        }
