    private void panel1_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
    {
          System.Windows.Forms.TextBox txtbox = new System.Windows.Forms.TextBox();
          txtbox.Location = e.Location;  //Creates the textbox where user double clicked
          panel1.Controls.Add(txtbox);
          txtbox.Focus();
          txtbox.Visible = true;
    }
