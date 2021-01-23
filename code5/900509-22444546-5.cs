    void watcher_Changed(object sender, FileSystemEventArgs e)
    {
        if (e.Name == "TestFile.txt")
            using (StreamReader sr = new StreamReader(e.FullPath))
            {
                String line = sr.ReadToEnd();
                Console.WriteLine(line);
            }
    }
