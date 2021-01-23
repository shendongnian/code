    var filenames = new[] { "D1_H1.txt", "D2_H1.txt", "D3_H2.txt" };
    var words = new[] { "Red", "Green", "Blue" };
    var counters = 
      filenames.Select(filename => Path.Combine(@"C:\Users\Niyomal N\Desktop\Assignment\Assignment", filename))
               .SelectMany(filepath => File.ReadAllLines(filepath))
               .SelectMany(line => line.Split(new[] { ' ' }))
               .Where(word => words.Contains(word))
               .GroupBy(word => word, (key, values) => new
                  {
                     Word = key,
                     Count = values.Count()
                  })
               .ToDictionary(g => g.Word, g => g.Count);
