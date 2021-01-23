    foreach (string newPath in Directory.GetFiles(@"\\xxx\yyy", "*.*", SearchOption.AllDirectories))
    {
        If(!newPath.Equals(NameOfFolderNotToInclude))
            File.Copy(newPath, newPath.Replace(@"\\xxx\yyy", @"C:\bbb"));
    }
            using (StreamWriter w = File.AppendText(Logging.fullLoggingPath))
            {
                Logging.Log("All necessary files copied to C:\\bbb", w);
            }
