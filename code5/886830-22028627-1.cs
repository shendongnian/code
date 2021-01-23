    static void Print(List<int> list, int charactersPerLine)
    {
        foreach (var batch in list.Batch(charactersPerLine)) 
        {
            var strBatch = batch.Select(e => e.ToString()).ToArray();
            Console.WriteLine(string.Join(",", strBatch));
        }
    }
