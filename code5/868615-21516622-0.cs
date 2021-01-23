    private void DisplayPicturebox_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                graphics = DisplayPicturebox.CreateGraphics();
                SolidBrush MysolidBrush = new SolidBrush(Color.Red);
                float newX = (float)DisplayPicturebox.Image.Size.Width / (float)DisplayPicturebox.Size.Width;
                float newY = (float)DisplayPicturebox.Image.Size.Height / (float)DisplayPicturebox.Size.Height;
                graphics = Graphics.FromImage(DisplayPicturebox.Image);
                graphics.FillEllipse(MysolidBrush, e.X * newX, e.Y * newY, Convert.ToInt32(toolStripTextBox1.Text), Convert.ToInt32(toolStripTextBox1.Text));
                DisplayPicturebox.Refresh();
            }
        }
