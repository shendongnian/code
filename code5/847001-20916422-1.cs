    //Common eventhandler assigned to all of your PictureBox.Click Events
    private void pictureBox_Click(object sender, EventArgs e)
    {
        ((PictureBox)sender).Visible = false;
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
