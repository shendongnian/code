    var files = Directory.EnumerateFiles(pathDirectory, names, SearchOption.AllDirectories);
    if (!files.Any())
    {
       lblMessage.Text = "Missing file: " + names;
       return false;
    }
