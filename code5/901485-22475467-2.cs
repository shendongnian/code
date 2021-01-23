    IEnumerable<Tuple<
            string,
            string,
            string,
            string,
            string,
            string,
            string,
            string,>> ReadEights(string fileName)
    {
        var parts = File.ReadAllText(fileName).Split(new[] { '|' });
        if (parts.Length % 8 != 0)
        {
            throw new InvalidOperationException(
                string.Format(
                    "File \"{0}\" does not contain a valid set of whole lines",
                    fileName));
        }
        for (var line  = 0; line < parts.Length / 8; line++)
        {
            yield return Tuple.Create(
                parts[line],
                parts[line + 1],
                parts[line + 2],
                parts[line + 3],
                parts[line + 4],
                parts[line + 5],
                parts[line + 6],
                parts[line + 7]);
        }
    }
