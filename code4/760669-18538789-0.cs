    var rangeStrings = new List<string> { "[a-d]", "[A-H]", "[c,d]", "[B,C]", "[03-05]" };
    var separator = new[] { "-", "," };
    IEnumerable<IEnumerable<string>> ranges = rangeStrings
        .Select(rs =>
        {
            string inner = rs.Replace("[", "").Replace("]", "");
            string[] token = inner.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            bool isNumeric = token[0].All(Char.IsDigit);
            int start, end;
            if(isNumeric)
            {
                start = int.Parse(token.First());
                end = int.Parse(token.Last());
            }
            else
            {
                start = (int)token.First().First();
                end = (int)token.Last().Last();
            }
            var range = Enumerable.Range(start, end - start + 1)
                .Select(i => isNumeric ? i.ToString() : ((Char)i).ToString());
            return range;
        });
    foreach (var range in ranges)
    {
        Console.WriteLine("Range: {0}", string.Join(",", range));
    }
