    private void pictureBox1_Click(object sender, EventArgs e)
    {
        pictureBox1.Visible = false;
    }
    private void Form1_Click(object sender, EventArgs e)
    {
        foreach (var item in this.Controls) // or whatever your container control is
        {
            if(item is PictureBox)
            {
                PictureBox pb = (PictureBox)item;
                if (pb.Bounds.Contains(PointToClient( MousePosition)))
                {
                    pb.Visible = true;
                }
            }
        }
    }
