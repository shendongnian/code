    foreach (Control c in this.Controls)
    {
        if (c.Height > 25)
        {
            c.BackColor = Color.Red;
            pictureBox1.Location = new Point(x1, y1);
            if (pictureBox1.Bounds.IntersectsWith(c.Bounds))
            {
                isCollide = true;
                label1.Text = "true";
                c.BackColor = Color.Green;
                break;
            }
            else
            {
                isCollide = false;
                label1.Text = "false";
            }
        }
    }
