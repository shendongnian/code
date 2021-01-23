    using (TextWriter writer = File.CreateText(@"c:\actors.txt"))
    {
        foreach (string actor in ActorArrayList)
        {
            writer.WriteLine(actor);
        }
    }
