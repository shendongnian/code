        int b = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.ShowDialog();
            for (int z = 0; z < ofd.FileNames.Length ; z++)
            {
                Image img = Image.FromFile(ofd.FileNames[z]);
                string a = b.ToString();
                imageList1.Images.Add(a, img);
                var listViewItem = listView1.Items.Add("1");
                listViewItem.ImageKey = a;
                b++;
            }
        }
