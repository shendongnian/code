    Task.Run(() =>
    {
        foreach (string newPath in Directory.GetFiles(clipsSource, "*.*", SearchOption.AllDirectories))
        {
            i++;
            File.Copy(newPath, newPath.Replace(clipsSource, Dest + "\\clips"), true);
            Dispatcher.Invoke(() => copyProgressLbl.Text = i.ToString());
        }
    });
