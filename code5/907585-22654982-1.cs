    List<Receptor> receptors = new List<Receptor>();
    var lines = File.ReadLines("Path").SkipWhile(l => !l.Contains("[some name]"));
    foreach (string line in lines)
    {
        if (line.Contains("[some name]"))
            receptors.Add(new Receptor(line));
        else
            receptors.Last().Codes.Add(line);
    }
