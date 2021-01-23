    string networkPath = "\\\\Network\\Path";
    foreach (string path in System.IO.Directory.GetFiles(networkPath))
    {
        foreach (string line in System.IO.File.ReadAllLines(path).SkipWhile(x => !x.Contains("[data start]")))
        {
             //Do something with line here
        }
    }
