     int b = 0;
        public void button1_Click_1(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.ShowDialog();
            for (int z = 0; z < ofd.FileNames.Length; z++)
            {
                Image img = Image.FromFile(ofd.FileNames[z]);
                string a = b.ToString();
                imageList1.Images.Add(a, img);
                var listViewItem = listView1.Items.Add(ofd.FileName );
                listViewItem.ImageKey = a;
                b++;
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s= listView1.SelectedItems.ToString();
           Bitmap bm= new Bitmap (@"" +s);
           pictureBox1.Image = bm;
        }
