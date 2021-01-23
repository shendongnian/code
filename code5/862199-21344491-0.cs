    List<Song> songs = File.ReadLines(path)
        .Where(line => !String.IsNullOrWhiteSpace(line))
        .Select((line, index) => new { line, index })  
        .GroupBy(x => x.index / 3)  // integer division trick
        .Select(grp => new Song
        {
            Duration = TimeSpan.Parse(grp.First().line.Trim()),
            Title = grp.ElementAt(1).line.Trim(),
            Interpret = grp.ElementAt(2).line.Trim()
        }).ToList();
