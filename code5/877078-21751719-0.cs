    private void SelectFileButton_Click(object sender, EventArgs e)
    {
        DialogResult dr = this.openFileDialog1.ShowDialog();
        if (dr == System.Windows.Forms.DialogResult.OK)
        {
            images.Clear();
            // Read the files 
            foreach (String file in openFileDialog1.FileNames)
            {
                // Create a PictureBox. 
                images.Add(Image.FromFile(file));
            }
            if (images.Count > 0)
            {
                currentImageIndex = 0;
                pictureBox1.Image = images[currentImageIndex];
            }
        }
    }
