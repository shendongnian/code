        private void Form1_Load(object sender, EventArgs e)
        {
            getPictures(); // load pics from hdd
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(((FileInfo)listBox1.SelectedItem).FullName);
        }
        private void getPictures()
        {
            string[] filters = { "*.jpg", "*.jpeg", "*.png", "*.gif", "*.bmp" };
            // change path to yours
            var directory = new DirectoryInfo(@"C:\Users\Public\Pictures\Sample Pictures");
            var files = new List<FileInfo>();
            foreach (var filter in filters)
            {
                var results = directory.GetFiles(filter, SearchOption.AllDirectories);
                files.AddRange(results);
            }
            foreach (var file in files)
            {
                listBox1.Items.Add(file);
            }
            // not quite sure what this code should do - so I comment out - as I do not think it is necessary for your question!
            //var dialog = new FolderBrowserDialog();
            //var result = dialog.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    string path = dialog.SelectedPath;
            //    lblText.Text = path;
            //}
        }
