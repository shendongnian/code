    var files = Directory.GetFiles(path);
    foreach (var f in files)
    {
        var info = new FileInfo(f);
        var name = info.Name.Split('.')[0];
        var extension = info.Name.Split('.')[1];
        int i;
        if (int.TryParse(name, out i))
        {
            File.Move(info.FullName, string.Format(@"{0}\{1}.{2}", path, i + 5, extension));
        }
    }
