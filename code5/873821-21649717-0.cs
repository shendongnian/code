    private void Picturemethod(object sender, MouseEventArgs e)
    {
        if (sender is PictureBox) { ((PictureBox)sender).Visible = false; }
        else { /* Do nothing or throw ArgumentException */ }
    }
