    public static class MapHelper
    {
        public static void defineMapArea(this Control parent, PaintEventHandler handler)
        {
            PictureBox pictureBox1 = new PictureBox();
            // Dock the PictureBox to the form and set its background to white.
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.BackColor = Color.White;
            // Connect the Paint event of the PictureBox to the event handler method.
            pictureBox1.Paint += handler;
            // Add the PictureBox control to the Form. 
            parent.Controls.Add(pictureBox1);
        }
    }
