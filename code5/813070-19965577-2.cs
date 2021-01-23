    foreach (var m in Matches)
    {
        string site;
        if (StringsToSites.TryGetValue(m.Text, out site))
        {
            Console.WriteLine("Text '{0}' matches site '{1}'.", m.Text, site);
        }
    }
