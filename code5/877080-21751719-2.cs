    private void SelectFileButton_Click(object sender, EventArgs e)
    {
        DialogResult dr = this.openFileDialog1.ShowDialog();
        if (dr == System.Windows.Forms.DialogResult.OK)
        {
            loadedImages.Clear();
            // Read the files 
            foreach (String file in openFileDialog1.FileNames)
            {
                // Create a PictureBox. 
                loadedImages.Add(Image.FromFile(file));
            }
            if (loadedImages.Count > 0)
            {
                currentImageIndex = 0;
                pictureBox1.Image= loadedImages[currentImageIndex];
            }
        }
    }
