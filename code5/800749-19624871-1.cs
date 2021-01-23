        string text;
        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
        using (var sr = new StreamReader(path))
        {
            text = sr.ReadToEnd();
        }
