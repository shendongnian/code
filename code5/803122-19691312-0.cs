    string filepath = @"F:\Apps Development\Coursework\3_Coursework\3_Coursework\bin\Debug\Pics";
    
    private void Form1_load(object sender, EventArgs e)
    {
        lstImages.Items.AddRange(Directory.GetFiles(filepath, "*.jpg")
                                          .Select(f => Path.GetFileName(f)).ToArray());
    }
    
    private void lstImages_SelectedIndexChanged(object sender, EventArgs e)
    {
        pictureBox1.ImageLocation = Path.Combine(filepath, lstImages.SelectedItem.ToString());
    }
