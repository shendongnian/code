        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DirectoryInfo dinfo = new DirectoryInfo(@"C:\cake");
            FileInfo[] Files = dinfo.GetFiles("*.jpeg");
            listBox1.Items.AddRange(Files);
            listBox1.DisplayMember = "FileName";
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                FileInfo fi = (FileInfo)listBox1.SelectedItem;
                pictureBox1.ImageLocation = fi.FullName;
            }
        }
