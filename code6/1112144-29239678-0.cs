        int tileIndex = 0;
        const int tileSmall = 30;
        const int tileMed = 70;
        const int tileLarge = 110;
        private void button1_Click(object sender, EventArgs e)
        {
            Label l = new Label();
            l.AutoSize = false;
            l.BackColor = Color.Green;
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.Margin = new Padding(5);
            l.Text = string.Format("Tile {0}", tileIndex++);
            switch (r.Next(3))
            {
                case 0: l.Width = tileSmall; break;
                case 1: l.Width = tileMed; break;
                case 2: l.Width = tileLarge; break;
            }
            switch (r.Next(3))
            {
                case 0: l.Height = tileSmall; break;
                case 1: l.Height = tileMed; break;
                case 2: l.Height = tileLarge; break;
            }
            flowLayoutPanel1.Controls.Add(l);
        }
