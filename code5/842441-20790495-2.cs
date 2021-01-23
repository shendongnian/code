    private static long CountWordsInstances(string filePath, string searchTerm)
    {
        using (var reader = new StreamReader(filePath))
        {
            long wordCount = 0;
            var separators = new[] { '.', '?', '!', ' ', ';', ':', ',' };
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                wordCount +=
                    line.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                        .Count(x => x.Equals(searchTerm, StringComparison.OrdinalIgnoreCase));
            }
            return wordCount;
        }
    }
