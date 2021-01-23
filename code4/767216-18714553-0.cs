    public static void DefineMapArea(Form form, Action<object, PaintEventArgs> handler)
    {
        if (form == null)
        {
            throw new ArgumentNullException("form");
        }
        if (handler == null)
        {
            throw new ArgumentNullException("handler");
        }
        PictureBox pictureBox1 = new PictureBox();
        // Dock the PictureBox to the form and set its background to white.
        pictureBox1.Dock = DockStyle.Fill;
        pictureBox1.BackColor = Color.White;
        // Connect the Paint event of the PictureBox to the event handler method.
        pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(handler);
        // Add the PictureBox control to the Form. 
        form.Controls.Add(pictureBox1);
    }
