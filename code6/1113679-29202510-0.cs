    public IEnumerable<string> Modify(IEnumerable<string> items)
    {
        foreach(string item in items)
        {
           yield return "blah";
        }
    }
