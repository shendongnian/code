    class spielfeld
    {
        int[,] spielfeldgitter = new int[16, 16];
        public void spielfeldnullsetzen(/*PictureBox pictureBox1*/)
        {
            for (int i = 0; i < spielfeldgitter.GetLength(0); i++)
            {
                for (int j = 0; j < spielfeldgitter.GetLength(1); j++)
                {
                    spielfeldgitter[i, j] = 0;
                }
            }
        }
        public void spielfeldol(PictureBox pictureBox1)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics feld = Graphics.FromImage(bmp);
            for (int i = 0; i < 16; i++)
            {
                feld.DrawLine(Pens.Black, 0, (320 / 16) * i, 320, (320 / 16) * i);
            }
            for (int i = 0; i < 16; i++)
            {
                feld.DrawLine(Pens.Black, (320 / 16) * i, 0, (320 / 16) * i, 320);
            }
            pictureBox1.Image = bmp;
        }
        public void mouseclick(int eX, int eY, PictureBox pictureBox1)
        {
            int cellw = (eX / 20);
            int cellh = (eY / 20);
            if (spielfeldgitter[cellw, cellh] != 1)
            {
                spielfeldgitter[cellw, cellh] = 1;
                Graphics rectangle = Graphics.FromImage(pictureBox1.Image);
                rectangle.FillRectangle(Brushes.Green, ((320 / 16) * cellw + 1), (320 / 16) * cellh + 1, (320 / 16) - 1, (320 / 16) - 1);
            }
            else
            {
                spielfeldgitter[cellw, cellh] = 0;
                Graphics rectangle = Graphics.FromImage(pictureBox1.Image);
                rectangle.FillRectangle(Brushes.White, ((320 / 16) * cellw + 1), (320 / 16) * cellh + 1, (320 / 16) - 1, (320 / 16) - 1);
            }
            pictureBox1.Refresh();
        }
    }
