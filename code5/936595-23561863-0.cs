        int x = -1;
        int y = 50;
        Random rnd = new Random();
        bool check = true;
        int[,] pos;
        int index = -1;
        private void Form1_Load(object sender, EventArgs e)
        {
        //Initalize array
        pos = new int[pictureBox1.Width + 2, 2];
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics graphic = pictureBox1.CreateGraphics();
            if (x < pictureBox1.Width)
            {
                index++;
                x++;
            }
            else
            {
                graphic.Clear(Color.Black);
                for (int i = 0; i < pictureBox1.Width; i++)
                {
                    pos[i, 1] = pos[i + 1, 1];
                    graphic.DrawRectangle(System.Drawing.Pens.Lime, pos[i, 0], pos[i, 1], 1, 1);
                }
            }
            graphic.DrawRectangle(System.Drawing.Pens.Lime, x, y, 1, 1);
            pos[index, 0] = x;
            pos[index, 1] = y;
            graphic.Dispose();
            //for random dots
            //y = rnd.Next(5, 95);
            
            //for line
            if (check)
                y++;
            else
                y--;
            if (y == 100)
                check = false;
            if (y == 5)
                check = true;
        }
