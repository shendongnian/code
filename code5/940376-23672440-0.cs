    public IEnumerable<IDandAGE> ReadDocGrabValues(string fileREAD)
    {
        foreach(string j in File.ReadLines(fileREAD))
        {
            yield return new IDandAGE(j.Substring(0, 15), j.Substring(16, 1),
                j.Substring(18, 6), j.Substring(25, 6), 0,
                DateTime.Today, DateTime.Today);
        }
    }
    ...
    foreach (IDandAGE w in ReadDocGrabValues(path))
    {
        // do per-item processing
    }
