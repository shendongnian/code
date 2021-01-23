    foreach (string newPath in Directory.GetFiles(@"\\xxx\yyy", "*.*", SearchOption.AllDirectories))
    {
        if(Path.GetDirectory(newPath) != PathToExclude)
            File.Copy(newPath, newPath.Replace(@"\\xxx\yyy", @"C:\bbb"), true);
    }
            using (StreamWriter w = File.AppendText(Logging.fullLoggingPath))
            {
                Logging.Log("All necessary files copied to C:\\bbb", w);
            }
