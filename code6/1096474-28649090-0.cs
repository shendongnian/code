    IEnumerable<Adjacent> CountAdjacents(List<string> source)
    {
        var result = new List<Adjacent>();
        for (var i = 0; i < source.Count() - 1; i++)
        {
            if (source[i] == source[i + 1])
            {
                if (result.Any(x => x.Word == source[i]))
                {
                    result.Single(x => x.Word == source[i]).Quantity++;
                }
                else
                    result.Add(new Adjacent
                    {
                        Word = source[i],
                        Quantity = 2
                    });
            }
        }
        return result;
    }
    class Adjacent
    {
        public string Word;
        public int Quantity;
    }
