    static IEnumerable<string[]> ReadCsv(string path)
    {
        using (var stream = new StreamReader(path))
        {
            var line = stream.ReadLine();
            if (line != null)
            {
                var count = line.Count(x => x == ',') + 1;
                while ((line = stream.ReadLine()) != null)
                {
                    var data = line
                        .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                        .Take(count)
                        .ToArray();
                    yield return data;
                }
            }
        }
    }
