        private Ball ball = new Ball();
        private Bat bat = new Bat();
        public class Ball : Form1
        {
            public int Xpos { get; set; }
            public int Ypos { get; set; }
            public void Draw()
            {
                brushSize = 15;
                paper.FillEllipse(brush, Xpos, Ypos, brushSize, brushSize);
            }
            public void Move(int xDir, int yDir)
            {
                timer1.Interval = randomNumber.Next(50, 100);
                timer1.Enabled = true;
                Xpos = Xpos + xDir;
                Ypos = Ypos + yDir;
                if (x >= picBox.Width)
                    xDir = -xDir;
                if (y >= picBox.Height)
                    yDir = -yDir;
                if (x <= 0)
                    xDir = -xDir;
                if (y <= 0)
                    yDir = -yDir;
            }
        }
        public class Bat : Form1
        {
            public int Xpos { get; set; }
            public int Ypos { get; set; }
            public void Draw()
            {
                paper.FillRectangle(brushBlue, xBat - 25, picBox.Height - 20, 50, 10);
            }
        }
