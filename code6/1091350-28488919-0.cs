     bool formOpen = false;
     Form form;        // <<-- the reference to the 2nd form
    private void Form1_Load(object sender, EventArgs e)
    {
        pictureBox1.MouseHover += pictureBox1_MouseHover;
        pictureBox1.MouseLeave +=pictureBox1_MouseLeave;
        pictureBox1.MouseMove += pictureBox1_MouseMove;   // <<-- the mouve event handler
    }
     
    // the move event
    void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        // the best loacation is up to you, may have to toggle depending on the cursor position..!
        if (form != null) form.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
    }
    void pictureBox1_MouseHover(object sender, EventArgs e)
    {
        if (formOpen == false)
        {
            form = new Form();  // no longer a local variable!!
