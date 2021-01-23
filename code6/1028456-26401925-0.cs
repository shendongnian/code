    using (TextWriter writer = File.CreateText(@"actors.txt"))
    {
        foreach (string actor in ActorArrayList)
        {
            writer.WriteLine(actor);
        }
    }
