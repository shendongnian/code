    private void pictureBox_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            p = (PictureBox)sender;
            p.Tag = p.Location; // <-- store the Location in the Tag() property
            // ... rest of the existing code ...
        }
    }
