    string name = txtNameSubstring.Text;
    var allFiles = System.IO.Directory.GetDirectories("C:\\Temp").Where(x => x.Contains(name));//
    
    if (!allFiles.Any())
    {
       MessageBox.Show("No files found");
    }
    cblFolderSelect.Items.AddRange(allFiles);
