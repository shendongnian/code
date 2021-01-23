		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				e.Handled = true;
				// draw foreground to background
				using (var g = Graphics.FromImage(pictureBox1.Image))
					g.DrawImage(Foreground, 0, 0);
				// clear foreground
				using (var g = Graphics.FromImage(Foreground))
					g.Clear(Color.Transparent);
			}
			else if (e.KeyCode == Keys.Space)
			{
				e.SuppressKeyPress = true;
				e.Handled = true;
				// a random number source - probably better at form level
				var rnd = new Random();
				// draw a new random ellipse
				using (var g = Graphics.FromImage(Foreground))
				{
					g.Clear(Color.Transparent);
					g.DrawEllipse(Pens.Red, 0, 0, 30 + rnd.Next(500), 30 + rnd.Next(500));
				}
				// tell Windows to redraw the paintBox to show new foreground image
				pictureBox1.Invalidate();
			}
		}
