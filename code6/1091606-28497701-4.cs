    private void PBoxJigsaw1_MouseUp(object sender, MouseEventArgs e)
    {
        if(panel.Controls.Count > 0) 
        {
            return; // Panel already contains an item, stop executing the code
        }
        if (sender != null && sender.GetType() == typeof(PictureBox))
        {
            ....
