    void dataFromFile()
    {
        if (!File.Exists(filename))
            return;
        var people = File.ReadLines(filename)
                         .Select(line => line.Split(' '))
                         .Select(m => new { Name = m[0], Height = int.Parse(m[1]) })
                         .OrderBy(p => p.Height); // here
       foreach (var person in people)
       {
           Rectangle r = new Rectangle { 
                           Height = person.Height, 
                           Width = 25,
                           Fill = Brushes.Red
                         };
           Canvas.SetLeft(r, rnd(200));
           Canvas.SetTop(r, 200);
           table.Children.Add(r);
       }
    }
