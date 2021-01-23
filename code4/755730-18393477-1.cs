    static IEnumerable<string> traverse(string path, Func<string, bool> filter)
    {
        foreach (string f in Directory.GetFiles(path).Where(filter))
        {
            yield return f;
        }
    
        foreach (string d in Directory.GetDirectories(path))
        {
            foreach (string f in traverse(d, filter))
            {
                yield return f;
            }
        }
    }
