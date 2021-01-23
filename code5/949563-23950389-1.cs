    string spcdirectorypath = @"C:\Users";
    string spcfiletape = "*.*";
    DirectoryInfo d = new DirectoryInfo(spcdirectorypath);//Assuming Test is your Folder
    
    if(HasAccessToFolder(spcdirectorypath))
    {
        FileInfo[] Files = d.GetFiles(spcfiletape, SearchOption.AllDirectories); //Getting Text files
        foreach (FileInfo file in Files)
        {
           string str = file.FullName + "\n";
           richTextBox1.AppendText(str);
        }
    }
