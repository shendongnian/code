    void watcher_Changed(object sender, FileSystemEventArgs e)
    {
        using (StreamReader sr = new StreamReader(e.FullPath))
        {
            String line = sr.ReadToEnd();
            Console.WriteLine(line);
        }
    }
