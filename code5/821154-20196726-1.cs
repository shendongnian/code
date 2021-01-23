    foreach(string file in Directory.EnumerateFiles(path, "*", 
        SearchOption.AllDirectories))
    {
        System.IO.File.AppendAllText("e:\\personal\\tests.txt",
            System.IO.Path.GetFileName(file) + ":" + rootFolder + "\n")
    }
