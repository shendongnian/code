    private void listBox_Assets_SelectedIndexChanged(object sender, EventArgs e)
    {
        string file = IO.Path.Combine("the directory", listBox_Assets.SelectedItem);
        if (IO.File.Exists(file)) 
        {
          pictureBox1.Image = Image.FromFile(file);
        }
    }
