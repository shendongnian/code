    public static void loadCombo(ComboBoxEdit control) 
    {
            string path = @"C:\FolderWithRepxFiles\";
            string[] filePaths = Directory.GetFiles(path, "*.repx");
            control.Properties.Items.Clear();
            foreach (string item in filePaths)
                control.Properties.Items.Add(System.IO.Path.GetFileNameWithoutExtension(item));
    }
