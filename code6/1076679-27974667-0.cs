        private int direction = -1; // this can be values other than 1 to make it jump farther each move
        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = enemy.Location.X + direction;
            if (x <= 0)
            {
                direction = -1 * direction;
                x = 0;
            }
            else if (x >= this.ClientRectangle.Width - enemy.Width)
            {
                direction = -1 * direction;
                x = this.ClientRectangle.Width - enemy.Width;
            }
            enemy.Location = new Point(x, enemy.Location.Y);
        }
