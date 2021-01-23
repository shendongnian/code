    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            listLeft.Columns.Add(new ColumnHeader());
            FolderBrowserDialog folderPicker = new FolderBrowserDialog();
            listLeft.View = View.Details;
            if (folderPicker.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo di = new DirectoryInfo(folderPicker.SelectedPath);
                FileInfo[] files = di.GetFiles();
                DirectoryInfo[] directories = di.GetDirectories();
    
                foreach (DirectoryInfo directory in directories)
                {
                    listLeft.Items.Add("Directory " + directory.Name);
                }
                foreach (FileInfo file in files)
                {
                    listLeft.Items.Add(file.Name);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
