    void dataFromFile()
    {
        if (!File.Exists(filename))
            return;
        var people = File.ReadLines(filename)
                         .Select(line => line.Split(' '))
                         .Select(m => new { Name = m[0], Height = int.Parse(m[1]) })
                         .OrderBy(p => p.Height); // here
        var bars = people.Select(p =>
                new Rectangle { Height = p.Height, Width = 25, Fill = Brushes.Red });
       foreach (var bar in bars)
       {
           Canvas.SetLeft(bar, rnd(200));
           Canvas.SetTop(bar, 200);
           table.Children.Add(bar);
       }
    }
