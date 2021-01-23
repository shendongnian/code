            Image test = Properties.Resources.checker_black;
            PictureBox b = new PictureBox();
            b.Parent = GameBoard;
            b.Image = test;
            b.Width = test.Width*2;
            b.Height = test.Height*2;
            b.Location = new Point(0, 90);
            b.BackColor = Color.Transparent;
            b.BringToFront();
