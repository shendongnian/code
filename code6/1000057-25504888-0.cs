    private void GetFilesinDirectory(string directory,string targetdirectory)
    {
        string [] directories = Directory.GetDirectories(directory);
        if(directories.Length >= 1)
        {
            for (int i = 0; i < directories.Length; i++)
            {
                GetFilesinDirectory(directories[i], targetdirectory);
            }
        }
        string[] files = Directory.GetFiles(directory);
        if (files.Length >= 1)
        {
            for (int i = 0; i < files.Length; i++)
        {
            string filename = Path.GetFileName(files[i]);
            string directoryname = directory.Replace(InstallfoldervalueLabel.Text + "\\Appfiles\\", String.Empty)
                                                .Replace("\\","___");
                if (!File.Exists(sourcefoldervalueLabel.Text + "\\" + filename))
                {
                    File.Copy(directory+ "\\" + filename, targetdirectory + directoryname + "___" + filename, true);
                }
            }
        }
    }
