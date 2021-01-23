            getPictures();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(((FileInfo)listBox1.SelectedItem).FullName);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void getPictures()
        {
            string[] filters = { "*.jpg", "*.jpeg", "*.png", "*.gif", "*.bmp" };
            string resulPath = ""; // var that will hold the path that returns on the user search
            // not quite sure what this code should do - so I comment out - as I do not think it is necessary for your question!
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = dialog.SelectedPath;
                resulPath = path;
            }
            // Here i set the DirectoryInfo with the var resulPath
            var directory = new DirectoryInfo(@"" + resulPath + "");
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
        }
    
