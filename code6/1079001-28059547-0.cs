    private string fileName;
    public void button2_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog open = new OpenFileDialog())
        {
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // image in picture box
               filename = open.FileName;
               pictureBox1.Image = new Bitmap(open.FileName);
               pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
               // image file path
               string path = Directory.GetCurrentDirectory();
               textBox1.Text = Path.GetDirectoryName(open.FileName);
            }
        }
    }
    public void button1_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            return;
        }
        int selectedIndex = comboBox1.SelectedIndex;
        Object selectedItem = comboBox1.SelectedItem;
        if ((string)comboBox1.SelectedItem == "*.jpg")
        {
           pictureBox1.Image.Save(@"" + textBox1.Text + fileName + "", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
