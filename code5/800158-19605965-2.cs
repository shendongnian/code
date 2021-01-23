    string curDir = Environment.CurrentDirectory;  //By assuming that ListBox1 stores just file names and that the target directory is the one where the application is located 
    foreach (string item in listBox1.Items)
    {
         if (item != null && item.Trim().Length > 0)
         {
             string curPath = curDir + @"\" + item;
             if (File.Exists(curPath))
             {
                 FileInfo file = new FileInfo(curPath);
                 listBox2.Items.Add(DecToHex(file.Length));
             }
         }
    }
