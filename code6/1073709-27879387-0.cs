        private void btnOpen_Click(object sender, EventArgs e)
        {
            string[] Folders = Directory.GetDirectories(txtFolder.Text);
            
            var dataSource = new List<ListItem>();
            foreach (string f in Folders)
            {
                ListItem n = new ListItem();
                n.Value = f;
                n.Key = Path.GetFileName(f);
                dataSource.Add(n);
            }
            listBoxSidra.DataSource = dataSource;
            listBoxSidra.DisplayMember = "key";
            listBoxSidra.ValueMember = "value";
        }
