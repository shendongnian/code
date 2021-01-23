    void dataFromFile()
    {
        if (!File.Exists(filename))
            return;
        var people = File.ReadLines(filename)
                         .Select(line => line.Split(' '))
                         .Select(m => new { name = m[0], length = int.Parse(m[1]) })
                         .OrderBy(x => x.length); // here
       foreach (var data in people)
       {
           Rectangle r = new Rectangle { Height = data.length, Width = 25, Fill = Brushes.Red };
           Canvas.SetLeft(r, rnd(200));
           Canvas.SetTop(r, 200);
           table.Children.Add(r);
       }
    }
