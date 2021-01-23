    private void Form1_MouseClick(object sender, MouseEventArgs e)
    {
        Label lbl = new Label();
        lbl.Location = e.Location;
        lbl.Text = "Hello World";
        this.Controls.Add(lbl);
    }
   
