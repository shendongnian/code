    class TestClass
    {
        internal static void defineMapArea(Form1 form)
        {
            PictureBox pictureBox1 = new PictureBox();
            // Dock the PictureBox to the form and set its background to white.
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.BackColor = Color.White;
            // Connect the Paint event of the PictureBox to the event handler method.
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(form.pictureBox1_Paint);
            // Add the PictureBox control to the Form. 
            form.Controls.Add(pictureBox1);
        }
    }
