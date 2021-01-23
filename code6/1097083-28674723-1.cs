    void pb_MouseDown(object sender, MouseEventArgs e)
    {
        var img = (PictureBox)sender;
        img.Image.Tag = path; // this can be already set earlier or e.g. copied from pb.Tag (if pb.Tag is used to store path)
        img.DoDragDrop(img.Image, DragDropEffects.Move);
    }
    void PictureBox1DragDrop(object sender, DragEventArgs e)
    {
        PictureBox1.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
        var path = PictureBox1.Image.Tag.ToString();
    }
