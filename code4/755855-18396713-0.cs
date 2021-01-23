    string name = txtNameSubstring.Text;
    string[] allFiles = System.IO.Directory.GetFiles("C:\\Temp");//Change path to yours
    foreach (string file in allFiles)
    {
       if (file.Contains(name))
       {
          cblFolderSelect.Items.Add(file);
          // MessageBox.Show("Match Found : " + file);
       }
    }
    if(cblFolderSelect.Items.Count==0)
    {
       MessageBox.Show("No files found");
    }
