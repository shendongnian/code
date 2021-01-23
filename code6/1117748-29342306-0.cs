    public void ShowContents (TextWriter writer)
    {
        foreach (KeyValuePair<string, int> item in dictionary) {
            writer.WriteLine ("{0}: {1}", item.Key, item.Value);
        }
    }
    // calling in production code
    ShowContents(Console.Out);
