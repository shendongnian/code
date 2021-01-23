    private void picture_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog dlg = new OpenFileDialog())
        {
            dlg.Title = "Open Image";
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg *.jpe; *.jfif; *.png";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Panel panel = (Panel) ((Button)sender).Parent;
                PictureBox myPict = panel.Controls.Find("loaded", true)[0]; //Enter your own search string here
                myPict.Add(new Bitmap(dlg.FileName));
            }
         }
     }
