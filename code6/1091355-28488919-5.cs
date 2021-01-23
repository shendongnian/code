    // class level variable 
    Form form;
    private void Form1_Load(object sender, EventArgs e)
    {
        pictureBox1.MouseEnter += pictureBox1_MouseEnter;
        pictureBox1.MouseLeave +=pictureBox1_MouseLeave;
        pictureBox1.MouseMove += pictureBox1_MouseMove;  // here we move the form..
    }
    // .. with a little offset. The exact numbers depend on the cursor shape
    void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if ((form != null) && form.Visible)
        {
            form.Location = new Point(Cursor.Position.X + 5, Cursor.Position.Y + 5);
        }
    }
    void pictureBox1_MouseEnter(object sender, EventArgs e)
    {
        // we create it only once. Could also be done at startup!
        if (form == null)
        {
             form = new Form();
             form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
             //form.BackColor = Color.Orchid;
             form.Name = "imageForm";
             this.AddOwnedForm(form);
             form.BackColor = Color.Black;
             form.Dock = DockStyle.Fill;
             form.Size = new Size(30, 30);
             form.BackgroundImageLayout = ImageLayout.Center;
             //this.TopMost = true;  // wrong! this will steal the focus!!
             form.ShowInTaskbar = false;
        }
        // later we only show and update it..
        form.Show();
        form.Location = new Point(Cursor.Position.X + 5, Cursor.Position.Y + 5);
        // we want the Focus to be on the main form!
        Focus();
    }
    private void pictureBox1_MouseLeave(object sender, EventArgs e)
    {
        if (form!= null) form.Hide();
    }
