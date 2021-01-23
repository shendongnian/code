    using System.IO;
    string networkPath = "\\\\Network\\Path";
    foreach (string path in Directory.GetFiles(networkPath, "*.txt"))
    {
        foreach (string line in File.ReadAllLines(path).SkipWhile(x => !x.Contains("[data start]")))
        {
             //Do something with line here
        }
    }
